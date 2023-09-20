using Concessionaria.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria.Model.Repositories
{
    public class RepositoryVeiculo : RepositoryBase<Veiculo>
    {
        public RepositoryVeiculo(bool saveChanges = true) : base(saveChanges)
        {

        }

        public async Task<Veiculo> SelecionarPkConcessionariaAsync(params object[] variavel)
        {
            if (variavel.Length > 0)
            {
                var concessionariaId = (int)variavel[0];

                var obj = await _context.Set<Veiculo>()
                    .FirstOrDefaultAsync(v => v.ConcessionariaIdConcessionaria == concessionariaId);

                return obj;
            }

            return null;
        }
    }
}
