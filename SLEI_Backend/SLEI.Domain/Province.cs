using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLEI.Domain
{
 public   class Province
    {

        public int ProvinceId { get; set; }

        public string NomProvince { get; set; }

        public int? ImageId { get; set; } // clé étrangère
        public Image image { get; set; }
        public List<Ville> Villes { get; set; }
    }
}
