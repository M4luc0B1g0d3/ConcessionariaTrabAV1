using Concessionaria.Model.Interfaces;
using Concessionaria.Model.Models;
using Concessionaria.Model.Repositories;
using Concessionaria.View.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Concessionaria.View.Controllers
{
    public class ConcessionariaController : Controller
    {
        private RepositoryConcessionaria repositoryConcessionaria;
        private RepositoryVeiculo repositoryVeiculo;
        public ConcessionariaController()
        {
            repositoryConcessionaria = new RepositoryConcessionaria();
            repositoryVeiculo = new RepositoryVeiculo();
        }
        public async Task<IActionResult> Index()
        {
            var listaConcessionaria = await repositoryConcessionaria.SelecionarTodosAsync();
            
            return View(listaConcessionaria);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Model.Models.Concessionaria concessionaria)
        {
            var oConcessionaria = await repositoryConcessionaria.IncluirAsync(concessionaria);

            return RedirectToAction("Index", oConcessionaria);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var loja = await repositoryConcessionaria.SelecionarPkAsync(id);

            return View(loja);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Model.Models.Concessionaria concessionaria)
        {
            if (ModelState.IsValid)
            {
                var oConcessionaria = await repositoryConcessionaria.AlterarAsync(concessionaria);

                return RedirectToAction("Index", oConcessionaria);
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var detalhe = await repositoryConcessionaria.SelecionarPkAsync(id);

            return View(detalhe);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var concessionaria = await repositoryConcessionaria.SelecionarPkAsync(id);

            return View(concessionaria);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Model.Models.Concessionaria concessionaria)
        {
            var loja = await repositoryConcessionaria.SelecionarPkAsync(concessionaria.IdConcessionaria);

            var veiculo = await repositoryVeiculo.SelecionarPkConcessionariaAsync(concessionaria.IdConcessionaria);
            if (veiculo != null)
            {
                ViewData["Erro"] = "Erro";
                return View(loja);
            }
            await repositoryConcessionaria.ExcluirAsync(loja);
            return RedirectToAction("Index");
        }
    }
}
