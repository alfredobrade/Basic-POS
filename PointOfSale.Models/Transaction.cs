using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int BusinessUnitId { get; set; }
        public int? CashRegisterId { get; set; }
        public CashRegister? CashRegister { get; set; }
        public BusinessUnit? BusinessUnit { get; set; }

        public DateTime? DateTime { get; set; }
        public string? Description { get; set; }
        public decimal? Amount { get; set; }
        public bool? IsExpense { get; set; }


        public int? OperationTypeId { get; set; }
        public OperationType? OperationType { get; set; }


        public int? UserId { get; set; }
    }
}
