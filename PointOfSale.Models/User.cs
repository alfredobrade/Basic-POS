using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        
        public ICollection<UserRole>? Roles { get; set; }
        public ICollection<UserBusinessUnit>? UserBusinessUnits { get; set; }
        
        public int? YakaAgentId { get; set; }

    }
}
