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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly POSContext _context;
        public UserRepository(POSContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<UserRole>> GetUserRoles(int userId)
        {
            try
            {
                var roles = await _context.UsersRoles.Include(r => r.Role)
                    .Where(u => u.UserId == userId).ToListAsync();
                return roles;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
