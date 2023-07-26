using Microsoft.EntityFrameworkCore;
using PointOfSale.DAL.Context;
using PointOfSale.DAL.IRepository;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.DAL.Repository
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly POSContext _context;
        public SaleRepository(POSContext context) : base(context)
        {
            _context = context;
        }

        //dejo este para no inyectar ProductRepository en SaleService
        public async Task<Product> GetProductById(long ProductId) 
        {
            try
            {
                var product = await _context.Products.FindAsync(ProductId);
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Sale> GetSaleComplete(long saleId)
        {
            try
            {
                var list = await _context.Sales.Where(sp => sp.Id == saleId).FirstOrDefaultAsync();//TODO: faltan los include
                return list;
            }catch (Exception)
            {
                throw;
            }
        }

        public async Task<Sale> CreateNewSale(int BusinessUnitId)
        {
            try
            {
                var newSale = new Sale()
                {
                    BusinessId = BusinessUnitId,
                    DateTime = null,
                    Cost = 0,
                    Price = 0,
                };
                await _context.Sales.AddAsync(newSale);
                await _context.SaveChangesAsync();
                return newSale;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateSale(Sale sale)
        {
            try
            {
                _context.Sales.Update(sale);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> AddSaleProduct(SaleProduct saleProduct)
        {
            try
            {
                await _context.SaleProducts.AddAsync(saleProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> DeleteSale(long saleId)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var saleProducts = _context.SaleProducts.Where(sp => sp.SaleId == saleId);
                foreach (var item in saleProducts)
                {
                    _context.SaleProducts.Remove(item);
                }

                var sale = _context.Sales.Find(saleId);
                _context.Sales.Remove(sale);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return false;
                throw;
            }
        }

        public async Task<IEnumerable<SaleProduct>> GetSaleDetail(long saleId)
        {
            try
            {
                var detail = await _context.SaleProducts.Include(p => p.Product).Where(s => s.SaleId == saleId).ToListAsync();
                return detail;

            }
            catch (Exception)
            {

                throw;
            }
        }

        

    }
}
