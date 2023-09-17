using Concessionaria.Model.Models;
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
    }
}
