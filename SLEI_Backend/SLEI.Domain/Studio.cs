using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLEI.Domain
{
 public  class Studio
    {
        public int StudioId { get; set; }
        public string Statut { get; set; }

        public float Loyer { get; set; }

        [ForeignKey("Logement")]
        public int LogementId { get; set; }

        public List<Image> Images { get; set; }
        public Logement logement { get; set; }
        public List<RDV> RDVs { get; set; }
    }
}
