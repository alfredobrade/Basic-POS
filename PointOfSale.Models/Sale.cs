using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Sale
    {
        public long Id { get; set; }
        public DateTime? DateTime { get; set; }
        //public int? CustomerId { get; set; }
        //public Customer? Customer { get; set; }
        public string? CustomerName { get; set; }

        public decimal? Cost { get; set; }
        public decimal? Price { get; set; }

        public int? PayMethodId { get; set; }
        public PayMethod? PayMethod { get; set; }

        public int? SalesPersonId { get; set; }
        public SalesPerson? SalesPerson { get; set; }
        //TODO: sale

        public bool? IsSaleCompleted { get; set; } = false;


        public ICollection<SaleProduct>? SaleProducts { get; set; }

        public int? UserId { get; set; }
        public int BusinessUnitId { get; set; }
    }
}
