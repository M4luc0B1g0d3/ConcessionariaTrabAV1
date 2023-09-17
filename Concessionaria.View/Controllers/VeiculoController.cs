using Concessionaria.Model.Models;
using Concessionaria.Model.Repositories;
using Concessionaria.View.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;

namespace Concessionaria.View.Controllers
{
    public class VeiculoController : Controller
    {
        private RepositoryVeiculo repositoryVeiculo;
        private RepositoryConcessionaria repositoryConcessionaria;

        public VeiculoController()
        {
            repositoryVeiculo = new RepositoryVeiculo();
            repositoryConcessionaria = new RepositoryConcessionaria();
        }

        public IActionResult Index()
        {
            var listaVeiculosVM = VeiculoVM.ListarTodosVeiculos();
            return View(listaVeiculosVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var veiculo = await repositoryVeiculo.SelecionarPkAsync(id);
            CarregaDadosViewBag();
            return View(veiculo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                veiculo = await repositoryVeiculo.AlterarAsync(veiculo);
                CarregaDadosViewBag();
                return View(veiculo);
            }
            return View(veiculo);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var veiculoVM = VeiculoVM.SelecionarVeiculo(id);
            return View(veiculoVM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var veiculoVM = VeiculoVM.SelecionarVeiculo(id);
            return View(veiculoVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(VeiculoVM veiculoVM)
        {
            var auto = await repositoryVeiculo.SelecionarPkAsync(veiculoVM.Codigo);
            await repositoryVeiculo.ExcluirAsync(auto);
            return RedirectToAction("Index");
        }
        public void CarregaDadosViewBag()
        {
            ViewData["IdConcessionaria"] = new SelectList(repositoryConcessionaria.SelecionarTodos(), "IdConcessionaria", "Nome");
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarregaDadosViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            CarregaDadosViewBag();
            if (ModelState.IsValid)
            {
                veiculo = await repositoryVeiculo.IncluirAsync(veiculo);

                return View(veiculo);
            }
            else
            {
                return View(veiculo);
            }
        }
    }
}
