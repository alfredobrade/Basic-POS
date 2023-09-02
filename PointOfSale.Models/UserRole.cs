using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class UserRole
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public DateTime? InitialDate { get; set; }
        public int? NumMonths { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
