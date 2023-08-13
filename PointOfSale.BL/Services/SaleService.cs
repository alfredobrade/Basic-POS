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

        public async Task<bool> AddProduct(long saleId, long productId, int quantity)
        {
            try
            {
                var product = await _repository.GetProductById(productId); //dejo este para no traer repository de Product

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

        public async Task<Sale> CloseSale(long saleId, string customer)
        {
            try
            {
                var sale = await _repository.Get(s => s.Id == saleId);
                //sale.DateTime = DateTime.Now; Postgre no admite el mismo valor con zona horaria
                sale.DateTime = DateTime.UtcNow.AddHours(-3); //le seteo como UTC y le agrego las horas de la zona horaria
                sale.CustomerName = customer;
                //otros

                var saleProduct = await _repository.GetSaleDetail(saleId);

                foreach (var item in saleProduct)
                {
                    sale.Cost += item.Cost * item.Quantity;
                    sale.Price += item.Price * item.Quantity;
                }

                var result = await _repository.UpdateSale(sale);
                return sale;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> CancelSale(long saleId)
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

        public async Task<Sale> GetOpenSale(int? BusinessUnitId)
        {
            try
            {
                var result = await _repository.Get(s => s.BusinessUnitId == BusinessUnitId && s.DateTime == null);
                if (result != null)
                {
                    result.Cost = 0;
                    result.Price = 0; //TODO: borrar esto despues de la siguiente venta

                    var detail = await _repository.GetSaleDetail(result.Id);
                    foreach (var item in detail)
                    {
                        // se le asignan sumatoria de costos y precios calculados al momento
                        result.Cost += item.Cost * item.Quantity;
                        result.Price += item.Price * item.Quantity;
                    }
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<SaleProduct>> SaleDetail(long saleId) ////este queda aca porque sino hay que crear un repository mas
        {
            try
            {
                var detail = await _repository.GetSaleDetail(saleId);
                return detail;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Sale> GetSaleById(long saleId)
        {
            try
            {
                var sale = await _repository.Get(s => s.Id == saleId);
                return sale;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Sale>> GetSaleList(int? BusinessUnitId, DateTime? date, string? customer) //TODO: agregar params para el filtrado
        {
            try
            {
                var saleList = await _repository.GetList(s => s.BusinessUnitId == BusinessUnitId && s.DateTime.HasValue);

                if (date.HasValue && date.Value != DateTime.MinValue) saleList = saleList.Where(s => s.DateTime.Value.Date == date.Value.Date);
                if (!String.IsNullOrEmpty(customer))
                {
                    saleList = saleList.Where(s => s.CustomerName != null && s.CustomerName.ToLower().Contains(customer.ToLower()));
                }



                return saleList;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
