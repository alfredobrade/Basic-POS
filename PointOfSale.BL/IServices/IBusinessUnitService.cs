using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.BL.IServices
{
    public interface IBusinessUnitService
    {
        Task<IEnumerable<BusinessUnit>> GetBusinessUnits(int userId);
        Task<BusinessUnit> NewBusinessUnit(int userId, BusinessUnit businessUnit);
    }
}
