using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.BL.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetList(int? BusinessId);
        Task<Product> GetProduct(long Id);
        Task<Product> CreateProduct(Product product);
        Task<bool> EditProduct(Product product);
        Task<bool> DeleteProduct(Product product);
        Task<IEnumerable<Product>> FilterList(int? BusinessId, string? code, string? description);
    }
}
