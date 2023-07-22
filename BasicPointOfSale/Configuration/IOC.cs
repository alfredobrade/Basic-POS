using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using PointOfSale.BL.IServices;
using PointOfSale.BL.Services;
using PointOfSale.DAL.Context;
using PointOfSale.DAL.IRepository;
using PointOfSale.DAL.Repository;
using PointOfSale.Models;
using System.Xml.Linq;

namespace BasicPointOfSale.Configuration
{
    public static class IOC
    {
        public static void DependencyInyection(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<POSContext>(options =>
            //{
            //    options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));
            //});

            //services.AddNpgsql<POSContext>(builder.Configuration.GetConnectionString("TareasDb"));

            services.AddDbContext<POSContext>(options => options.UseNpgsql(configuration.GetConnectionString("DevConnection")));


            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISaleService, SaleService>();
            //services.AddScoped<IUtilidadesService, UtilidadesService>();
            //services.AddScoped<IRoleService, RoleService>();
            //services.AddScoped<IUsuarioService, UsuarioService>();


        }
    }
}
