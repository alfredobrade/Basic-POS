using PointOfSale.Models;

namespace BasicPointOfSale.Models
{
    public class ProductListVM
    {
        public int BusinessUnitId { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
