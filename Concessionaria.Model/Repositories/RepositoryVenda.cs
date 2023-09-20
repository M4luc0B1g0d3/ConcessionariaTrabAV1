using Concessionaria.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria.Model.Repositories
{
    public class RepositoryVenda : RepositoryBase<Venda>
    {
        public RepositoryVenda(bool saveChanges = true) : base(saveChanges)
        {

        }
        public async Task<Venda> SelecionarPkClienteAsync(params object[] variavel)
        {
            if (variavel.Length > 0)
            {
                var clienteId = (int)variavel[0];

                var obj = await _context.Set<Venda>()
                    .FirstOrDefaultAsync(v => v.ClienteIdCliente == clienteId);

                return obj;
            }

            return null;
        }

        public async Task<Venda> SelecionarPkVeiculoAsync(params object[] variavel)
        {
            if (variavel.Length > 0)
            {
                var veiculoId = (int)variavel[0];

                var obj = await _context.Set<Venda>()
                    .FirstOrDefaultAsync(v => v.VeiculoIdVeiculo == veiculoId);

                return obj;
            }

            return null;
        }

    }
}
