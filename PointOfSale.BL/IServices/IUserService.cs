using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.BL.IServices
{
    public interface IUserService
    {
        Task<User> Create(User user);
        Task<bool> Edit(User user);
        Task<bool> Delete(int id);
        Task<User> GetByEmail(string email);
        Task<User> ValidateUser(string email, string password);
        Task<List<UserRole>> GetUserRoles(int userId);
        Task<int> UsersQtity();
    }
}
