using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class County
    {
        public int Id { get; set; }
        public int UtcHourOffset { get; set; } = 0;

        public IEnumerable<ProvinceOrState> Provinces { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}
