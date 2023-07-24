using Microsoft.EntityFrameworkCore;
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
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repository;

        public SaleService(ISaleRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Sell(string customer, List<long> products) //TODO: es necesario el UserId?
        {
            try
            {
                var sale = new Sale
                {
                    //TODO: UserId?
                    DateTime = DateTime.Now,
                    CustomerName = customer,
                    SaleProducts = new List<SaleProduct>()
                };

                foreach (var productId in products)
                {
                    var product = await _repository.GetProductById(productId);

                    if (product != null)
                    {
                        var saleProduct = new SaleProduct
                        {
                            //Sale = sale,
                            Product = product
                        };
                        sale.SaleProducts.Add(saleProduct);

                        sale.Cost += product.Cost;
                        sale.Price += product.Price;
                    }
                }
                await _repository.Create(sale);

                return true;

            }
            catch (Exception) { throw; }

        }

        public async Task<Sale> NewSale(int BusinessUnitId)
        {
            try
            {
                return await _repository.CreateNewSale(BusinessUnitId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> AddProduct(int saleId, int productId, int quantity)
        {
            try
            {
                var product = await _repository.GetProductById(productId);

                var saleProduct = new SaleProduct()
                {
                    SaleId = saleId,
                    ProductId = productId,
                    Quantity = quantity,
                    Cost = product.Cost,
                    Price = product.Price,
                };

                await _repository.AddSaleProduct(saleProduct);

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
