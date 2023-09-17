using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concessionaria.Model.Repositories
{
    public class RepositoryConcessionaria : RepositoryBase<Models.Concessionaria>
    {
        public RepositoryConcessionaria(bool saveChanges = true) : base(saveChanges) 
        {

        }

    }
}
