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

        public async Task<Sale> NewSale(int BusinessUnitId) //TODO: agregar el nombre de customer
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

        //TODO: metodo para traer los articulos cargados y mostrar el monto de la venta antes de vender
        //la idea es que el cliente pueda ver el monto y eliminar productos o modif la cantidad

        //TODO: metodo para eliminar productos y otro para modificar cantidad o precio


        public async Task<Sale> CloseSale(int saleId)
        {
            try
            {
                var sale = await _repository.Get(s => s.Id == saleId);
                sale.DateTime = DateTime.Now;
                //otros

                var saleProduct = await _repository.GetSaleProducts(saleId);
                foreach (var item in saleProduct)
                {
                    sale.Cost += item.Cost;
                    sale.Price += item.Price;
                }

                var result = await _repository.UpdateSale(sale);
                return sale;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> CancelSale(int saleId)
        {
            try
            {
                var result = await _repository.DeleteSale(saleId);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
