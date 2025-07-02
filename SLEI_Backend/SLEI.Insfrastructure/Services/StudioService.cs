using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SLEI.Domain;
using SLEI.Domain.Repository;
using SLEI.Insfrastructure.Data;

namespace SLEI.Insfrastructure.Services
{
 public   class StudioService : StudioRepository 

    {
        private readonly SLEIContext _context = null;

        public StudioService(SLEIContext context)
        {
            _context = context;
        }

        public Studio AddStudio(Studio Std)
        {

        var result= this._context.Studios.Add(Std);
            this._context.SaveChanges();

            return result.Entity;
                
        }
    }
}
