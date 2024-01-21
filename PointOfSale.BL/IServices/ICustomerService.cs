using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.BL.IServices
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomer(int id);
        Task<IEnumerable<Customer>> GetCustomerList(int businessUnitId);
        Task<IEnumerable<Customer>> GetCustomersByName(int businessUnitId, string name);
        Task<Customer> CreateCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
        Task<bool> DeleteCustomer(Customer customer);
    }
}

