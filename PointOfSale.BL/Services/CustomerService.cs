using PointOfSale.BL.IServices;
using PointOfSale.DAL.IRepository;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.BL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _repository;
        public CustomerService(IGenericRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            try
            {
                var result = await _repository.Get(c => c.Id == id);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Customer>> GetCustomerList(int businessUnitId)
        {
            try
            {
                var result = await _repository.GetList(c => c.BusinessUnitId == businessUnitId);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<Customer>> GetCustomersByName(int businessUnitId, string name)
        {
            try
            {
                var list = await GetCustomerList(businessUnitId);
                var result = list.Where(c => c.Name.ToLower().Contains(name.ToLower())); //TODO: busca por contains
                //TODO: hay que hacer una view donde busca el customer y despues filtra por ese

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            try
            {
                var result = await _repository.Create(customer);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCustomer(Customer customer)
        {
            try
            {
                var result = await _repository.Delete(customer);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
