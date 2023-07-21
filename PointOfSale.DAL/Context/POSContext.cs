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

        public DbSet<Purchase>? Purchases { get; set; }
        public DbSet<PurchaseProduct>? PurchaseProducts { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<UserBusinessUnit> UserBusinessUnits { get; set; }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<CashRegister> CashRegisters { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<PayMethod> PayMethods { get; set; }
        public DbSet<SalesPerson> SalesPersons { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        

        




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
            modelBuilder.Entity<PurchaseProduct>()
                .HasKey(sp => new { sp.PurchaseId, sp.ProductId });
            modelBuilder.Entity<PurchaseProduct>()
                .HasOne(s => s.Purchase)
                .WithMany(sp => sp.PurchaseProducts)
                .HasForeignKey(s => s.PurchaseId);
            modelBuilder.Entity<PurchaseProduct>()
                .HasOne(p => p.Product)
                .WithMany(sp => sp.PurchaseProducts)
                .HasForeignKey(p => p.ProductId);

            //UserBusinessUnit
            modelBuilder.Entity<UserBusinessUnit>()
                .HasKey(sp => new { sp.UserId, sp.BusinessUnitId });
            modelBuilder.Entity<UserBusinessUnit>()
                .HasOne(s => s.User)
                .WithMany(sp => sp.UserBusinessUnits)
                .HasForeignKey(s => s.UserId);
            modelBuilder.Entity<UserBusinessUnit>()
                .HasOne(p => p.BusinessUnit)
                .WithMany(sp => sp.UserBusinessUnits)
                .HasForeignKey(p => p.BusinessUnitId);
        }
    }
}
