using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Tax
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public decimal? Amount { get; set; }
        public decimal? Porcentage { get; set;}

        //country province/state city
    }
}
