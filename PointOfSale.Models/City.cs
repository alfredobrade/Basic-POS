using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? UtcHourOffset { get; set; } = 0;

        public int? ProvinceOrStateId { get; set; }
        public int? CountryId { get; set; }
    }
}
