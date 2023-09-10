using Microsoft.EntityFrameworkCore.Storage;
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
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(POSContext context) : base(context)
        {
        }
    }
}
