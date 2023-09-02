using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.BL.IServices
{
    public interface ITransactionService
    {
        Task<Transaction> AddExpense(Transaction transaction);
        Task<Transaction> AddIncome(Transaction transaction);
        Task<IEnumerable<Transaction>> TransactionHistory(int BusinessUnitId, DateTime? date, string? description);
        Task<Transaction> GetTransaction(int id);
    }
}

