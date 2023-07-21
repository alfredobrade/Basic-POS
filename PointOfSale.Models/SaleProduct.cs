﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class SaleProduct
    {
        public long SaleId { get; set; }
        public Sale Sale { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
