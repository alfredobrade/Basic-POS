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
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;
        public UserService(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<User> Create(User user)
        {
            try
            {
                return await _repository.Create(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var user = await _repository.Get(u => u.Id == id);
                return await _repository.Delete(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Edit(User user)
        {
            try
            {
                return await _repository.Edit(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _repository.Get(u => u.Email.Equals(email));
        }
        public async Task<User> ValidateUser(string email, string password)
        {
            try
            {
                var user = await _repository.Get(u => u.Email == email && u.Password == password);
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UsersQtity()
        {
            try
            {
                return await _repository.Count();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
