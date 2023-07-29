using PointOfSale.Models;

namespace BasicPointOfSale.Models
{
    public class TransactionListVM
    {
        public int? BusinessUnitId { get; set; }
        public IEnumerable<Transaction>? Transactions { get; set; }
    }
}
