using PointOfSale.Models;

namespace BasicPointOfSale.Models
{
    public class SaleListVM
    {
        public int BusinessUnitId { get; set; }
        //public long SaleId { get; set; }
        public IEnumerable<Sale> Sales { get; set; }
    }
}
