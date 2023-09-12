using PointOfSale.Models;

namespace BasicPointOfSale.Models
{
    public class CustomerListVM
    {
        public int BusinessUnitId { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
