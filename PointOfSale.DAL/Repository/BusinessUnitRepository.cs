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
    public class BusinessUnitRepository : GenericRepository<BusinessUnit>, IBusinessUnitRepository
    {
        private readonly POSContext _context;

        public BusinessUnitRepository(POSContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserBusinessUnit>> GetBusinessUnits(int userId)
        {
            try
            {
                var list = await _context.UserBusinessUnits
                    .Include(b => b.BusinessUnit)
                    .Include(r => r.Role)
                    .Where(bu => bu.UserId == userId).ToListAsync();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserBusinessUnit> CreateBusinessUnitRelation(int userId, int businessUnitId)
        {
            try
            {
                var userBusinessUnit = new UserBusinessUnit()
                {
                    UserId = userId,
                    BusinessUnitId = businessUnitId,
                    //RoleId = 3 //TODO: crear un metodo para modificar el rol
                };
                await _context.UserBusinessUnits.AddAsync(userBusinessUnit);
                await _context.SaveChangesAsync();
                return userBusinessUnit;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
