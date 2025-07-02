using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SLEI.Domain
{
 public  class Appartement
    {

        public int AppartementId { get; set; }
        public string Statut { get; set; }
        public int NbreDePieces { get; set; }

        public float Loyer { get; set; }
        public List<Image> Images { get; set; }

        public int LogementId {get; set;} // cle etrangere 

        [JsonIgnore]
        public Logement logement { get; set; }
        
        public List<RDV> RDVs { get; set; }
    }

}
