using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SLEI.Domain
{
public class Image
    {
        public int ImageId { get; set; }
        public string Url { get; set; }


        public int? LogementId { get; set; } // cle etrangere
       
        [JsonIgnore]  // permet d'eviter les cycles lorsqu'on ajoute un Logement
        public Logement logement { get; set; }

        public int? AppartementId { get; set; }

        [JsonIgnore]
        public Appartement appartement { get; set; }

        public int? StudioId { get; set; }

        [JsonIgnore]
        public Studio studio { get; set; }

        [JsonIgnore]
        public Province province { get; set; }

        [JsonIgnore]
        public Ville ville { get; set; }
    }
}
