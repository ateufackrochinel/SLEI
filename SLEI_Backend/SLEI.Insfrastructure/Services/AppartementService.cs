using SLEI.Domain;
using SLEI.Domain.Repository;
using SLEI.Insfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLEI.Insfrastructure.Services
{
 public  class AppartementService: AppartementRepository
    {
        private readonly SLEIContext _context = null;

        public AppartementService (SLEIContext context)
        {
            this._context = context;
        }
        public Appartement AddAppartement(Appartement App)
        {
           var result= this._context.Appartements.Add(App);
            this._context.SaveChanges();

            return result.Entity;

        }
    }
}
