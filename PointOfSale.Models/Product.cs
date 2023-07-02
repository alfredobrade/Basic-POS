using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime? LastCostUpdate { get; set; }
        public decimal Cost { get; set; }
        public decimal? CostAccordingToExchange { get; set; }
        public decimal? Exchange { get; set; }
        public decimal? Price { get; set; } //el precio vamos a redondear en el servicio nomas
        public decimal? PriceAccordingToExchage { get; set; }
        public decimal? PorcentageOfProfit { get; set; }
        public decimal? Taxes { get; set; }

        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }

        public int? UOMId { get; set; }
        public UnitOfMeasure? UOM { get; set;}

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        
        public IEnumerable<Suplier>? Supliers { get; set; }

        //public IEnumerable<int> SuplierCode { get; set; } //como puedo implementar esto si tiene que estar referido al suplier

    }
}
