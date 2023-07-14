using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace NQT_BookStore.Models
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext()
        {

        }
        public ShoppingDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<BillDetails> BillDetails { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=TAINQ\SQLEXPRESS;Initial Catalog=NQT_BookStore;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
