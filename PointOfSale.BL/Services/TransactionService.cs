using Microsoft.EntityFrameworkCore;
using PointOfSale.BL.IServices;
using PointOfSale.DAL.Context;
using PointOfSale.DAL.IRepository;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.BL.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IGenericRepository<Transaction> _repository;
        private readonly POSContext _context;

        public TransactionService(IGenericRepository<Transaction> repository, POSContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<Transaction> AddExpense(Transaction transaction)
        {
            try
            {
                transaction.Amount = transaction.Amount * (-1);
                transaction.DateTime = DateTime.UtcNow.AddHours(-3);
                var result = await _repository.Create(transaction);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Transaction> AddIncome(Transaction transaction)
        {
            try
            {
                transaction.DateTime = DateTime.UtcNow.AddHours(-3);
                var result = await _repository.Create(transaction);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Transaction>> TransactionHistory(int BusinessUnitId, DateTime? date, string? description)
        {
            try
            {
                var list = await _repository.GetList(t => t.BusinessUnitId == BusinessUnitId && t.DateTime.HasValue, "CashRegister");

                //var list = await _context.Transactions
                //    .Include(c => c.CashRegister)
                //    .Where(t => t.BusinessUnitId == BusinessUnitId && t.DateTime.HasValue)
                //    .ToListAsync(); //TODO: usando context y tuve que poner ToList en todos lados

                if (date.HasValue && date.Value != DateTime.MinValue) list = list.Where(t => t.DateTime.Value.Date == date.Value.Date);
                if (!String.IsNullOrEmpty(description))
                {
                    list = list.Where(t => t.Description != null && t.Description.ToLower().Contains(description.ToLower()));
                }

                
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Transaction> GetTransaction(int id)
        {
            try
            {
                var model = await _repository.Get(t => t.Id == id, "CashRegister");

                //var model = await _context.Transactions
                //    .Include(c => c.CashRegister)
                //    .Where(c => c.Id == id).FirstOrDefaultAsync(); //TODO: usando context
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
