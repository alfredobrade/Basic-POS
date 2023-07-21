using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class ProductSupplier
    {
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
