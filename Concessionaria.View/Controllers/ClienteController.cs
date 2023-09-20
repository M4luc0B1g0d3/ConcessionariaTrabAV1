using Concessionaria.Model.Interfaces;
using Concessionaria.Model.Models;
using Concessionaria.Model.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Concessionaria.View.Controllers
{
    public class ClienteController : Controller
    {
        private RepositoryCliente repositoryCliente;
        private RepositoryVenda repositoryVenda;

        public ClienteController()
        {
            repositoryCliente = new RepositoryCliente();
            repositoryVenda = new RepositoryVenda();
        }
        public async Task<IActionResult> Index()
        {
            var listaClientes = await repositoryCliente.SelecionarTodosAsync();
            return View(listaClientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            var oCliente = await repositoryCliente.IncluirAsync(cliente);

            return RedirectToAction("Index", oCliente);
            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await repositoryCliente.SelecionarPkAsync(id);

            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var oCliente = await repositoryCliente.AlterarAsync(cliente);

                return RedirectToAction("Index", oCliente);
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var detalhes = await repositoryCliente.SelecionarPkAsync(id);

            return View(detalhes);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var detalhes = await repositoryCliente.SelecionarPkAsync(id);
            return View(detalhes);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Cliente cliente)
        {
            var oCliente = await repositoryCliente.SelecionarPkAsync(cliente.IdCliente);

            var venda = await repositoryVenda.SelecionarPkClienteAsync(cliente.IdCliente);
            if (venda != null)
            {
                ViewData["Erro"] = "Erro";
                return View(oCliente);
            }
            await repositoryCliente.ExcluirAsync(oCliente);
            return RedirectToAction("Index");
        }
    }
}
