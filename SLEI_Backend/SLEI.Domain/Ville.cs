using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SLEI.Domain
{
 public   class Ville
    {

        public int VilleId { get; set; }

        public string NomVille { get; set;  }

        public int? ImageId { get; set; } // clé étrangère
        public Image image { get; set; }

        [JsonIgnore]
        public List<Logement> Logements { get; set; }
        public  int ProvinceId { get; set; }
        public Province province { get; set; }
    }
}
