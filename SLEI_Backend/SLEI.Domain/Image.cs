using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLEI.Domain
{
public class Image
    {
        public int ImageId { get; set; }
        public string Url { get; set; }

        [ForeignKey("Logement")]
        public int? LogementId { get; set; }  //  <-- Optionnelle (NULL autorisé
        public Logement logement { get; set; }

        [ForeignKey("Appartement")]
        public int? AppartementId { get; set; }
        public Appartement appartement { get; set; }

        [ForeignKey("Studio")]
        public int? StudioId { get; set; }
        public Studio studio { get; set; }
    }
}
