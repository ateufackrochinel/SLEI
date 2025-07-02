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
 public   class LogementService: LogementRepository
    {

        private readonly SLEIContext _context = null;

        public LogementService(SLEIContext context)
        {
            this._context = context;
        }
        public Logement AddLogement(Logement Log)
        {
            var result = this._context.Logements.Add(Log);

            _context.SaveChanges(); // pour sauvegarder dans la base de donnees 
            return result.Entity;
        }

        public Logement findLogementByNom(string NomLogemnt)
        {
            return this._context.Logements.FirstOrDefault(l => l.NomLogement == NomLogemnt);
        }
    }
}
