﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Agent { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        public ICollection<ProductSupplier>? ProductSuppliers { get; set; }


        public int BusinessUnitId { get; set; }

    }
}
