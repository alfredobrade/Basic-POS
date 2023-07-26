using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.DAL.IRepository
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        Task<Product> GetProductById(long ProductId);
        Task<Sale> GetSaleComplete(long saleId);
        Task<Sale> CreateNewSale(int BusinessUnitId);
        Task<bool> UpdateSale(Sale sale);
        Task<bool> AddSaleProduct(SaleProduct saleProduct);
        Task<bool> DeleteSale(long saleId);
        Task<IEnumerable<SaleProduct>> GetSaleDetail(long saleId);
    }
}
