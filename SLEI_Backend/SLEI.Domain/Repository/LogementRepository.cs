using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLEI.Domain.Repository
{
  public   interface LogementRepository
    {

        public Logement AddLogement(Logement Log);

        public Logement findLogementByNom(string NomLogemnt);

        public List<Logement> findLogementByNomVille(string NomVille);
   }
}
