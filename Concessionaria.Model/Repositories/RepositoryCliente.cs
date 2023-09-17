using Concessionaria.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria.Model.Repositories
{
    public class RepositoryCliente : RepositoryBase<Cliente>
    {
        public RepositoryCliente(bool saveChanges = true) : base(saveChanges)
        {

        }
    }
}
