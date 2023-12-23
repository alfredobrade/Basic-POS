using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class CashRegister
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Amount { get; set; }

        public int BusinessUnitId { get; set; }

    }
}
