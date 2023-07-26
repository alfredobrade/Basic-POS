using PointOfSale.Models;

namespace BasicPointOfSale.Models
{
    public class SaleVM
    {
        public int BusinessUnitId { get; set; }
        public Sale Sale { get; set; }
        public IEnumerable<SaleProduct> Products { get; set; }
    }
}
