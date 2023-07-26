using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class ProvinceOrState
    {
        public int Id { get; set; }
        public IEnumerable<City>? Cities { get; set; }
        public int CountryId { get; set; }
    }
}
