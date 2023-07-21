using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class PurchaseProduct
    {
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
