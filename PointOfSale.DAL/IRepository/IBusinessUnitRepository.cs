using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.DAL.IRepository
{
    public interface IBusinessUnitRepository : IGenericRepository<BusinessUnit>
    {
        Task<IEnumerable<UserBusinessUnit>> GetBusinessUnits(int userId);
        Task<UserBusinessUnit> CreateBusinessUnitRelation(int userId, int businessUnitId);
    }
}
