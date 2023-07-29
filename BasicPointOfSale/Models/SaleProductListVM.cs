using PointOfSale.Models;

namespace BasicPointOfSale.Models
{
    public class SaleProductListVM
    {
        public int BusinessUnitId { get; set; }
        public long SaleId { get; set; }    
        public IEnumerable<Product> Products { get; set; }
    }
}
