using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLEI.Domain.Repository
{
 public   interface VilleRepository
    {
        public Ville FindVilleByNom(String NomVille);

    }
}
