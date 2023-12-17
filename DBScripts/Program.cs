// See https://aka.ms/new-console-template for more information

using DBScripts;
using Microsoft.EntityFrameworkCore;
using PointOfSale.DAL.Context;

Console.WriteLine("Hello, World!");
//string n = Console.ReadLine();

//for (int i = 0; i < int.Parse(n); i++)
//{
//    Console.WriteLine("Hello, World!" + i);


//}


//services.AddDbContext<POSContext>(options => options.UseNpgsql(configuration.GetConnectionString("DevConnection")));

//var _context = new POSContext();


// Configura las opciones de DbContext, reemplaza YourDbContextOptions con el tipo real
DbContextOptions<POSContext> dbContextOptions = new DbContextOptionsBuilder<POSContext>()
    .UseNpgsql("Server=bboawflhkcoz33rnv6js-postgresql.services.clever-cloud.com;Port=50013;Database=bboawflhkcoz33rnv6js;User Id=u0hjnypgj4c6muk7kf2n;Password=KqWZndvqFcwA7w4Th9fJ59cPRAjdyE;") // Reemplaza con tu cadena de conexión PostgreSQL
    .Options;

// Crea una instancia de POSContext pasando las opciones al constructor
using (POSContext context = new POSContext(dbContextOptions))
{
    // Crea una instancia de ContextConection utilizando POSContext
    ContextConection contextConnection = new ContextConection(context);

    // Llama al método SalesDBUpdate
    await contextConnection.SalesDBUpdate();

    // Haz algo con el resultado si es necesario
    //Console.WriteLine($"Se realizaron {actualizaciones} actualizaciones en la base de datos.");
}
Console.ReadLine();