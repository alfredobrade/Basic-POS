using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.BL.IServices
{
    public interface ICashRegisterService
    {
        Task<CashRegister> AddExpense(int BusinessUnitId, decimal? price);
        Task<CashRegister> AddIncome(int BusinessUnitId, decimal? price);
        Task<CashRegister> ViewCashRegister(int BusinessUnitId);
        Task<CashRegister> NewCashRegister(int BusinessUnitId, string name);


    }
}
