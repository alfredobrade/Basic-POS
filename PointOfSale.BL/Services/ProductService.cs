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
                var result = await _repository.GetList(p => p.BusinessId == BusinessId);
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

        public async Task<Product> Create(Product product)
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

        public async Task<bool> Edit(Product product)
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

        public async Task<bool> Delete(Product product)
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
    }
}
