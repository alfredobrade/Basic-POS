using PointOfSale.Models;

namespace BasicPointOfSale.Models
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }

        public int? Role { get; set; }


        public int? YakaAgent { get; set; }

        //public string[] Roles { get; set; }
        public int UsersQtity { get; set; } = 0; //cuando le puse nuleable me aparecio con un circulo rojo con cruz que no andaba en el metodo del AccessIndex



    }
}
