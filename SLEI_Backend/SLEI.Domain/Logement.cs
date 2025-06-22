using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLEI.Domain
{
 public  class Logement
    {


        public int LogementId { get; set; }
        public string NomLogement { get; set; }
        public string Descripction { get; set; }
        public string  Adresse { get; set; }
        public int  NbreAppartement { get; set; }

        public int NbreStudio { get; set; }

        public List<Image> Images { get; set; }

        public List<Appartement>  Appartements { get; set; }

        public List<Studio> Studios { get; set; }



        
    }
}
