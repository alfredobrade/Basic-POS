using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.BL.IServices
{
    public interface ISaleService
    {
        Task<bool> Sell(string customer, List<long> products);
        Task<Sale> NewSale(int BusinessUnitId);
        Task<bool> AddProduct(int saleId, int productId, int quantity);
        Task<Sale> CloseSale(int saleId);
        Task<bool> CancelSale(int saleId);
    }
}
