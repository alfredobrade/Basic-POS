using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? IdentificationNumber { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        public ICollection<Sale>? Sales { get; set; }

        public int BusinessUnitId { get; set; }


    }
}
