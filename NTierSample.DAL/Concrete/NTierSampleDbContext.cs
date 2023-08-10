using Microsoft.EntityFrameworkCore;
using NTierSample.DAL.Concrete.Configurations;
using NTierSample.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSample.DAL.Concrete
{
    public class NTierSampleDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-M1VM0HC\\TEW_SQLEXPRESS;Database=NTierDB;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new ShoppingListMapping());
            modelBuilder.ApplyConfiguration(new ListItemMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
