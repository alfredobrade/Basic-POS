using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class SaleProduct
    {
        public long SaleId { get; set; }
        public Sale Sale { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }

        public int? Quantity { get; set; }
        public decimal? Cost { get; set; }
        //descuento?
        public decimal? Price { get; set; }
        public bool? IsSaleCompleted { get; set;} = false;
    }
}
