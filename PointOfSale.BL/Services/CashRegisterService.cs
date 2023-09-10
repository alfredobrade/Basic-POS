using PointOfSale.BL.IServices;
using PointOfSale.DAL.IRepository;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.BL.Services
{
    public class CashRegisterService : ICashRegisterService
    {
        private readonly IGenericRepository<CashRegister> _repository;

        public CashRegisterService(IGenericRepository<CashRegister> repository)
        {
            _repository = repository;
        }

        public async Task<CashRegister> NewCashRegister(int BusinessUnitId, string name)
        {
            try
            {
                var cashRegister = new CashRegister()
                {
                    BusinessUnitId = BusinessUnitId,
                    Amount = 0,
                    Name = name
                };
                cashRegister = await _repository.Create(cashRegister);
                return cashRegister;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<CashRegister> AddExpense(int BusinessUnitId, decimal? price)
        {
            try
            {
                var cashRegister = await _repository.Get(cr => cr.BusinessUnitId == BusinessUnitId);
                
                cashRegister.Amount -= price;
                await _repository.Edit(cashRegister);
                return cashRegister;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CashRegister> AddIncome(int BusinessUnitId, decimal? price)
        {
            try
            {
                var cashRegister = await _repository.Get(cr => cr.BusinessUnitId == BusinessUnitId);
                cashRegister.Amount += price;
                await _repository.Edit(cashRegister);
                return cashRegister;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CashRegister> ViewCashRegister(int BusinessUnitId)
        {
            try
            {
                var cashRegister = await _repository.Get(cr => cr.BusinessUnitId == BusinessUnitId);
                return cashRegister;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<CashRegister>> CashRegisterList(int BusinessUnitId)
        {
            try
            {
                var cashRegister = await _repository.GetList(cr => cr.BusinessUnitId == BusinessUnitId);
                return cashRegister.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
