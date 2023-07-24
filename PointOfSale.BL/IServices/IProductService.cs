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
        Task<Product> Create(Product product);
        Task<bool> Edit(Product product);
        Task<bool> Delete(Product product);
    }
}
