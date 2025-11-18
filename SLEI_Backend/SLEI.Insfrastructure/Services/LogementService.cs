using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SLEI.Domain;
using SLEI.Domain.Repository;
using SLEI.Insfrastructure.Data;

namespace SLEI.Insfrastructure.Services
{
 public   class LogementService: LogementRepository
    {

        private readonly SLEIContext _context = null;
        private readonly VilleRepository _VilleRepository = null;

       // private readonly VilleService villeService;

        public LogementService(SLEIContext context, VilleRepository villeRepository)
        {
            this._context = context;
            //  this.villeService = villeService;
            this._VilleRepository = villeRepository;
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

        public List<Logement> findLogementByNomVille(string NomVille)
        {
            Ville ville =_VilleRepository.FindVilleByNom(NomVille);

            if (ville == null)
                return new List<Logement>();

            // Include permet ici de recuperer les images associees a chaque logement
            var logements = this._context.Logements.Include(logements=>logements.Images).Where(l => l.VilleId == ville.VilleId).ToList();

            return logements;

        }
    }
}
