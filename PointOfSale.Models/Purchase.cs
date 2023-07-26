using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        

        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public ICollection<PurchaseProduct>? PurchaseProducts { get; set;}

        public int BusinessUnitId { get; set; }

    }
}
