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

    }
}
