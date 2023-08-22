using PointOfSale.Models;

namespace BasicPointOfSale.Models
{
    public class DashBoardVM
    {
        public int? BusinessUnitId { get; set; } 
        public CashRegister CashRegister { get; set; }  
        public IEnumerable<Product> ProductsUnderMinStock { get; set; }

    }
}
