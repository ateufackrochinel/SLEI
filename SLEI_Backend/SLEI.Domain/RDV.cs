using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLEI.Domain
{
 public   class RDV
    {
        public int RDVId { get; set; }
        public string Motif { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly Heure { get; set; }

        // Relations optionnelles : un RDV peut concerner un appartement OU un studio

        [ForeignKey("Appartement")]
        public int? AppartementId { get; set; }
        public Appartement appartement { get; set; }

        [ForeignKey("Studio")]
        public int? StudioId { get; set; }
        public Studio studio { get; set; }

    }
}
