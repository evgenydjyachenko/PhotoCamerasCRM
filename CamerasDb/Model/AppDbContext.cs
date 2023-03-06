using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Reflection.Emit;

namespace CamerasDb.Model
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(): base("DefaultConnection")
        {

        }     
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Managerr> Managers { get; set; }
        public DbSet<Director> Directors { get; set; }

        //public DbSet<Access> Accesses { get; set; }
        public DbSet<Order> Orders { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Order>().HasAlternateKey(u => u.);
        //}

    }
}
