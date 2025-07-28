
using Microsoft.EntityFrameworkCore;
     using ECommerce.Domain;

     namespace ECommerce.Infrastructure;

     public class ECommerceDbContext : DbContext
     {
         public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

         public DbSet<Product> Products => Set<Product>();
         public DbSet<CartItem> CartItems => Set<CartItem>();

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Product>().HasKey(p => p.Id);
             modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2); // Specify precision and scale
             modelBuilder.Entity<CartItem>().HasKey(c => c.Id);
             modelBuilder.Entity<CartItem>()
                 .HasOne(c => c.Product)
                 .WithMany()
                 .HasForeignKey(c => c.ProductId);
         }
     }