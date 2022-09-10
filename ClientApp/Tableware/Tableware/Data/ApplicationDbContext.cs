using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tableware.Models;

namespace Tableware.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Order> Order { get; set; } = null!;
        public DbSet<OrderProduct> OrderProduct { get; set; } = null!;
        public DbSet<PickupPoint> PickupPoint { get; set; } = null!;
        public DbSet<Product> Product { get; set; } = null!;
        public DbSet<Role> Role { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=DESKTOP-Q76SINS;" +
                "Initial Catalog=Trade;"+
                "Integrated Security=True"
            );
        }/*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(builder =>
            {
                builder.HasNoKey();
                builder.ToTable("Product");
            });
        }*/
    }
}
