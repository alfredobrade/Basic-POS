using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using PointOfSale.Models;

namespace PointOfSale.DAL.Context
{
    public class POSContext : DbContext
    {
        public POSContext(DbContextOptions<POSContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }

        public DbSet<Supplier> Supliers { get; set; }
        public DbSet<ProductSupplier>? ProductSuppliers { get; set; }

        




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SaleProducts
            modelBuilder.Entity<SaleProduct>()
                .HasKey(sp => new {sp.SaleId, sp.ProductId});
            modelBuilder.Entity<SaleProduct>()
                .HasOne(s => s.Sale)
                .WithMany(sp => sp.SaleProducts)
                .HasForeignKey(s => s.SaleId);
            modelBuilder.Entity<SaleProduct>()
                .HasOne(p => p.Product)
                .WithMany(sp => sp.SaleProducts)
                .HasForeignKey(p => p.ProductId);

            //ProductSupliers
            modelBuilder.Entity<ProductSupplier>()
                .HasKey(sp => new { sp.SupplierId, sp.ProductId });
            modelBuilder.Entity<ProductSupplier>()
                .HasOne(s => s.Supplier)
                .WithMany(sp => sp.ProductSuppliers)
                .HasForeignKey(s => s.SupplierId);
            modelBuilder.Entity<ProductSupplier>()
                .HasOne(p => p.Product)
                .WithMany(sp => sp.ProductSuppliers)
                .HasForeignKey(p => p.ProductId);

            //PurchaseProducts
        }
    }
}
