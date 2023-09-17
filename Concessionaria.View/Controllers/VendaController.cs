using Concessionaria.Model.Models;
using Concessionaria.Model.Repositories;
using Concessionaria.View.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Concessionaria.View.Controllers
{
    public class VendaController : Controller
    {
        private RepositoryVenda repositoryVenda;
        private RepositoryCliente repositoryCliente;
        private RepositoryVeiculo repositoryVeiculo;

        public VendaController()
        {
            repositoryVenda = new RepositoryVenda();
            repositoryCliente = new RepositoryCliente();
            repositoryVeiculo = new RepositoryVeiculo();
        }
        public IActionResult Index()
        {
            var listaVendas = VendaVM.ListarTodasVendas();
            return View(listaVendas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarregaDados();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Venda venda)
        {
            CarregaDados();
            var oVenda = await repositoryVenda.IncluirAsync(venda);
            return View(oVenda);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var oVenda = await repositoryVenda.SelecionarPkAsync(id);
            CarregaDados();
            return View(oVenda);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Venda venda)
        {
            if (ModelState.IsValid)
            {
                var oVenda = await repositoryVenda.AlterarAsync(venda);

                return View(oVenda);
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";

            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var detalhes = VendaVM.SelecionarVenda(id);

            return View(detalhes);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var detalhes = VendaVM.SelecionarVenda(id);

            return View(detalhes);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(VendaVM venda)
        {
            var oVenda = await repositoryVenda.SelecionarPkAsync(venda.Codigo);
            await repositoryVenda.ExcluirAsync(oVenda);
            return RedirectToAction("Index");
        }

        public void CarregaDados()
        {
            ViewData["IdCliente"] = new SelectList(repositoryCliente.SelecionarTodos(), "IdCliente", "Nome");
            ViewData["IdVeiculo"] = new SelectList(repositoryVeiculo.SelecionarTodos(), "IdVeiculo", "Nome");
        }
    }
}
