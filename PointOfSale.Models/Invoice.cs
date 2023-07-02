using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        public string InvoiceType { get; set; }
        public int POSNumber { get; set; }
        public int InvoiceNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
