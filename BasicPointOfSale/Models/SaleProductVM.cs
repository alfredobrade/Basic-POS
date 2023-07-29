using PointOfSale.Models;

namespace BasicPointOfSale.Models
{
    public class SaleProductVM
    {
        public long SaleId { get; set; }
        public Product Product { get; set; }
        public int? Quantity { get; set; }
    }
}
