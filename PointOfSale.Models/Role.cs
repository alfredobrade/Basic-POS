using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsSystemRole { get; set; }


        public ICollection<UserRole>? Users { get; set; }
        //public ICollection<UserBusinessUnit>? BusinessUnits { get; set; }

    }
}
