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
    public class SaleProductService : ISaleProductService
    {
        private readonly IGenericRepository<SaleProduct> _repository;

        public SaleProductService(IGenericRepository<SaleProduct> repository)
        {
            _repository = repository;
        }

        public async Task<SaleProduct> GetSaleProduct(long saleId, long productId)
        {
            try
            {
                var saleProduct = await _repository.Get(sp => sp.SaleId == saleId && sp.ProductId == productId);
                return saleProduct;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateSaleProduct(SaleProduct saleProduct)
        {
            try
            {
                var result = await _repository.Edit(saleProduct);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteSaleProduct(long saleId, long productId)
        {
            try
            {
                var model = await GetSaleProduct(saleId, productId);
                var result = await _repository.Delete(model);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
