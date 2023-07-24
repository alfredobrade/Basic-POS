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
        Task<IEnumerable<SaleProduct>> GetSaleProducts(int saleId);
        Task<Sale> CreateNewSale(int BusinessUnitId);
        Task<bool> UpdateSale(Sale sale);
        Task<bool> AddSaleProduct(SaleProduct saleProduct);
        Task<bool> DeleteSale(int saleId);
    }
}
