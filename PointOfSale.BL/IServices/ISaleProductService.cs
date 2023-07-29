using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.BL.IServices
{
    public interface ISaleProductService
    {
        Task<SaleProduct> GetSaleProduct(long saleId, long productId);
        Task<bool> UpdateSaleProduct(SaleProduct saleProduct);
        Task<bool> DeleteSaleProduct(long saleId, long productId);
    }
}
