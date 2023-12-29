// See https://aka.ms/new-console-template for more information

using DBScripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PointOfSale.DAL.Context;

using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");
//string n = Console.ReadLine();

//for (int i = 0; i < int.Parse(n); i++)
//{
//    Console.WriteLine("Hello, World!" + i);


//}


//services.AddDbContext<POSContext>(options => options.UseNpgsql(configuration.GetConnectionString("DevConnection")));

//var _context = new POSContext();


// Configura las opciones de DbContext, reemplaza YourDbContextOptions con el tipo real
//DbContextOptions<POSContext> dbContextOptions = new DbContextOptionsBuilder<POSContext>()
//    .UseNpgsql("") // Reemplaza con tu cadena de conexión PostgreSQL
//.Options;


IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

string connectionString = configuration.GetConnectionString("DevConnection");

// Ahora puedes utilizar la cadena de conexión
DbContextOptions<POSContext> dbContextOptions = new DbContextOptionsBuilder<POSContext>()
    .UseNpgsql(connectionString)
    .Options;

// Crea una instancia de POSContext pasando las opciones al constructor
using (POSContext context = new POSContext(dbContextOptions))
{
    // Crea una instancia de ContextConection utilizando POSContext
    ContextConnection contextConnection = new ContextConnection(context);

    // Llama al método SalesDBUpdate
    var updates = contextConnection.DBUpdates();

    // Haz algo con el resultado si es necesario
    Console.WriteLine($"Se realizaron {updates} actualizaciones en la base de datos.");
}
Console.ReadLine();