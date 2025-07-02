using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLEI.Domain;
using SLEI.Domain.Repository;
using SLEI.Insfrastructure.Data;

namespace SLEI.Insfrastructure.Services
{
 public   class VilleService: VilleRepository 
    {

        private readonly SLEIContext _context =null;

        public VilleService(SLEIContext context)
        {
            this._context = context;
        }
        public Ville FindVilleByNom(String Nom)
        {
            //var result = this._context.Find(NomVille);

            return _context.Villes.FirstOrDefault(v => v.NomVille == Nom);
        }
    }
}
