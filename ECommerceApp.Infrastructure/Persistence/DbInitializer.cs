using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Infrastructure.Persistence;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (context.Products.Any()) return;

        context.Products.AddRange(
            new Product { Name = "VR Headset", Price = 299.99M, ImageUrl = "vr.png" },
            new Product { Name = "Wireless Mouse", Price = 49.99M, ImageUrl = "mouse.png" },
            new Product { Name = "Mechanical Keyboard", Price = 89.99M, ImageUrl = "keyboard.png" }
        );

        context.SaveChanges();
    }
}
