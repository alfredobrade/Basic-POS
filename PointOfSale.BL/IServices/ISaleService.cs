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
        Task<Sale> NewSale(int BusinessUnitId);
        Task<bool> AddProduct(long saleId, long productId, int quantity);
        Task<Sale> CloseSale(long saleId, string customer);
        Task<bool> CancelSale(long saleId);
        Task<Sale> GetOpenSale(int? BusinessUnitId);
        Task<IEnumerable<SaleProduct>> SaleDetail(long saleId); //este queda aca porque sino hay que crear un repository mas
        Task<Sale> GetSaleById(long saleId);
        Task<IEnumerable<Sale>> GetSaleList(int? BusinessUnitId, DateTime? date, string? customer);
    }
}
