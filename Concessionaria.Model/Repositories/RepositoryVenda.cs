using Concessionaria.Model.Models;
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
    }
}
