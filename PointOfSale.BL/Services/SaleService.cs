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
    }
}
