using Concessionaria.Model.Interfaces;
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
        private RepositoryVenda repositoryVenda;

        public VeiculoController()
        {
            repositoryVeiculo = new RepositoryVeiculo();
            repositoryConcessionaria = new RepositoryConcessionaria();
            repositoryVenda = new RepositoryVenda();
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
                var oVeiculo = await repositoryVeiculo.AlterarAsync(veiculo);

                return RedirectToAction("Index", oVeiculo);
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";

            return View();
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

            var venda = await repositoryVenda.SelecionarPkClienteAsync(veiculoVM.Codigo);
            if (venda != null)
            {
                veiculoVM = VeiculoVM.SelecionarVeiculo(veiculoVM.Codigo);
                ViewData["Erro"] = "Erro";
                return View(veiculoVM);
            }
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

                return RedirectToAction("Index", veiculo);
            }
            else
            {
                return RedirectToAction("Index", veiculo);
            }
        }
    }
}
