using Concessionaria.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Concessionaria.View.ViewModel
{
    public class VendaVM
    {
        [HiddenInput(DisplayValue = false)]
        [DisplayName("Codigo")]
        public int Codigo { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CodigoVeiculo { get; set; }

        [DisplayName("Nome do Veiculo")]
        [Required(ErrorMessage = "O Nome do Veiculo é obrigatório")]
        public string NomeVeiculo { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CodigoCliente { get; set; }

        [DisplayName("Nome do Cliente")]
        [Required(ErrorMessage = "O Nome do Cliente é Obrigatório")]
        public string NomeCliente { get; set; }

        [DisplayName("Data Da Venda")]
        [Required(ErrorMessage = "A Data da Venda é Obrigatória")]
        public DateTime? DataVenda { get; set; }

        public VendaVM()
        {
            
        }
        public static VendaVM SelecionarVenda(int id)
        {
            var db = new ConcessionariaDBContext();
            var venda = db.Venda.Find(id);
            return new VendaVM()
            {
                Codigo = venda.IdVenda,
                CodigoVeiculo = venda.VeiculoIdVeiculo,
                NomeVeiculo = db.Veiculo.Find(venda.VeiculoIdVeiculo).Nome,
                CodigoCliente = venda.ClienteIdCliente,
                NomeCliente = db.Cliente.Find(venda.ClienteIdCliente).Nome,
                DataVenda = venda.DataVenda,
            };
        }
        public static List<VendaVM> ListarTodasVendas()
        {
            var db = new ConcessionariaDBContext();
            var listaRetorno = new List<VendaVM>();
            var listaVendas = db.Venda.ToList();

            foreach (var v in listaVendas)
            {
                var venda = new VendaVM();
                venda.Codigo = v.IdVenda;
                venda.CodigoVeiculo = v.VeiculoIdVeiculo;
                venda.NomeVeiculo = db.Veiculo.FirstOrDefault(x => x.IdVeiculo== v.VeiculoIdVeiculo).Nome;
                venda.CodigoCliente = v.ClienteIdCliente;
                venda.NomeCliente = db.Cliente.FirstOrDefault(x => x.IdCliente == v.ClienteIdCliente).Nome;
                venda.DataVenda = v.DataVenda;
                listaRetorno.Add(venda);
            }
            return listaRetorno;
        }

    }
}
