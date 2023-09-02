using PointOfSale.DAL.Repository;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.DAL.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<UserRole>> GetUserRoles(int userId);
    }
}
