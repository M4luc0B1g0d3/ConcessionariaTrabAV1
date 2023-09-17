using Concessionaria.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Concessionaria.View.ViewModel
{
    public class VeiculoVM
    {
        [HiddenInput(DisplayValue = false)]
        [DisplayName("Codigo")]
        public int Codigo { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CodigoConcessionaria { get; set; }

        [DisplayName("Nome da Concessionaria")]
        [Required(ErrorMessage = "A Concessionaria é obrigatória")]
        public string NomeConcessionaria { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O Nome do veiculo é Obrigatório")]
        public string Nome { get; set;}

        [DisplayName("Ano")]
        [Required(ErrorMessage = "O Ano é Obrigatório")]
        public int? Ano { get; set;}

        [DisplayName("Fabricante")]
        [Required(ErrorMessage = "O Fabricante é Obrigatório")]
        public string Fabricante { get; set;}

        [DisplayName("Usado")]
        public bool Usado { get; set;}

        [DisplayName("Preço")]
        [Required(ErrorMessage = "O Preço é Obrigatório")]
        public decimal? Preco { get; set;}

        [DisplayName("Tipo Do Veiculo")]
        [Required(ErrorMessage = "O tipo do veiculo é obrigatório")]
        public string Tipo { get; set;}

        public VeiculoVM()
        {

        }

        public static VeiculoVM SelecionarVeiculo(int id)
        {
            var db = new ConcessionariaDBContext();
            var veiculo = db.Veiculo.Find(id);
            return new VeiculoVM()
            {
                Codigo = veiculo.IdVeiculo,
                CodigoConcessionaria = veiculo.ConcessionariaIdConcessionaria,
                NomeConcessionaria = db.Concessionaria.Find(veiculo.ConcessionariaIdConcessionaria).Nome,
                Nome = veiculo.Nome,
                Ano = veiculo.Ano,
                Fabricante = veiculo.Marca,
                Usado = veiculo.Usado,
                Preco = veiculo.Preco,
                Tipo = veiculo.TipoVeiculo,
            };
        }
        public static List<VeiculoVM> ListarTodosVeiculos()
        {
            var db = new ConcessionariaDBContext();
            var listaRetorno = new List<VeiculoVM>();
            var listaVeiculos = db.Veiculo.ToList();

            foreach ( var v in listaVeiculos)
            {
                var veiculo = new VeiculoVM();
                veiculo.Codigo = v.IdVeiculo;
                veiculo.CodigoConcessionaria = v.ConcessionariaIdConcessionaria;
                veiculo.NomeConcessionaria = db.Concessionaria.FirstOrDefault(x => x.IdConcessionaria == v.ConcessionariaIdConcessionaria).Nome;
                veiculo.Nome = v.Nome;
                veiculo.Ano = v.Ano;
                veiculo.Fabricante = v.Marca;
                veiculo.Usado = v.Usado;
                veiculo.Preco = v.Preco;
                veiculo.Tipo = v.TipoVeiculo;
                listaRetorno.Add(veiculo);
            }
            return listaRetorno;
        }



    }
}
