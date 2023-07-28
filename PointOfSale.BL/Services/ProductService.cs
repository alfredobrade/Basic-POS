using PointOfSale.BL.IServices;
using PointOfSale.DAL.IRepository;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.BL.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductService(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetList(int? BusinessId)
        {
            try
            {
                var result = await _repository.GetList(p => p.BusinessUnitId == BusinessId);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Product>> FilterList(int? BusinessId, string? code, string? description)
        {
            try
            {
                var result = await _repository.GetList(p => p.BusinessUnitId == BusinessId);
                if (!String.IsNullOrEmpty(code)) result = result.Where(x => x.Code.Contains(code));
                if (!String.IsNullOrEmpty(description)) result = result.Where(x => x.Description.ToLower().Contains(description.ToLower()));

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Product> GetProduct(long Id)
        {
            try
            {
                var result = await _repository.Get(p => p.Id == Id);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Product> CreateProduct(Product product)
        {
            try
            {
                var result = await _repository.Create(product);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> EditProduct(Product product)
        {
            try
            {
                var result = await _repository.Edit(product);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            try
            {
                var result = await _repository.Delete(product);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Product>> ProductsUnderMinStock(int? BusinessId)
        {
            try
            {
                var result = await _repository.GetList(p => p.BusinessUnitId == BusinessId && p.Stock < p.StockMin);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
