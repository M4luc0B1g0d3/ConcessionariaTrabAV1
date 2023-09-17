using Concessionaria.Model.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Concessionaria.View.Controllers
{
    public class ConcessionariaController : Controller
    {
        private RepositoryConcessionaria repositoryConcessionaria;
        public ConcessionariaController()
        {
            repositoryConcessionaria = new RepositoryConcessionaria();
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

            return View(oConcessionaria);
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

                return View(oConcessionaria);
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
        public async Task<IActionResult> Deletar(Model.Models.Concessionaria concessionaria)
        {
            var loja = await repositoryConcessionaria.SelecionarPkAsync(concessionaria.IdConcessionaria);
            await repositoryConcessionaria.ExcluirAsync(loja);
            return RedirectToAction("Index");
        }
    }
}
