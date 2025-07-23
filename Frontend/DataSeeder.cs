using ECommerce.Domain;

namespace ECommerce.Infrastructure;

public static class DataSeeder
{
    public static void SeedProducts(ECommerceDbContext context)
    {
        if (context.Products.Any())
            return;

        var products = new List<Product>
        {
            new Product
            {
                Name = "MacBook Pro M3 Max",
                Description = "16-inch MacBook Pro with M3 Max chip, 64GB RAM, 2TB SSD.",
                Price = 3999.99m,
                ImageUrl = "https://www.istore.com.ng/cdn/shop/files/MacBook_Pro_16_in_M3_Pro_Max_Space_Black_PDP_Image_Position-1__WWEN_de97454c-5c57-46f3-9e95-52ae7c896d93_5000x.jpg?v=1700852370"
            },
            new Product
            {
                Name = "iPhone 15 Pro Max",
                Description = "6.7-inch Super Retina XDR display, A17 Pro, 256GB, Natural Titanium.",
                Price = 1199.00m,
                ImageUrl = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-15-pro-finish-select-202309-6-1inch?wid=5120&hei=2880&fmt=jpeg&qlt=80&.v=1692923760803"
            },
            new Product
            {
                Name = "iPad Pro 13-inch (M4)",
                Description = "13-inch Ultra Retina XDR display, M4 chip, 512GB, Wi-Fi.",
                Price = 1499.00m,
                ImageUrl = "https://cdsassets.apple.com/live/7WUAS350/images/tech-specs/ipad-pro-11-inch-13-inch.png"
            },
            new Product
            {
                Name = "AirPods Pro (2nd Gen, USB-C)",
                Description = "Spatial audio, Active Noise Cancellation, MagSafe case with USB-C.",
                Price = 249.00m,
                ImageUrl = "https://store.storeimages.cdn-apple.com/1/as-images.apple.com/is/ultra-case-unselect-gallery-1-202409?wid=5120&hei=3280&fmt=p-jpg&qlt=80&.v=aTVJSEliNW9jb25zalBlTm16VmMxcWpkNHRJWDMzcTg3NWRxV0pydTcvSUxMekYrWHVDVjVJT1ZDYVlkUjdVUnc2NytHaDA2aFdROEtrekNxcXV6T3VmenhDNGxXRVM5RSs4RlRpMXdYVWhCUjJHK0dyT0t2cDF1RTlMancyMG8"
            },
            new Product
            {
                Name = "Apple Watch Ultra 2",
                Description = "49mm Titanium Case with Alpine Loop, S9 SiP, 36-hour battery.",
                Price = 799.00m,
                ImageUrl = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/watch-ultra2-alpine-loop-orange-gallery-1-202309?wid=2000&hei=2000&fmt=jpeg&qlt=80&.v=1693700985986"
            },
            new Product
            {
                Name = "Apple Vision Pro",
                Description = "Spatial computer with dual 4K micro‑OLED displays and eye tracking.",
                Price = 3499.00m,
                ImageUrl = "https://store.storeimages.cdn-apple.com/1/as-images.apple.com/is/vision-pro-gallery-measure-dual-loop-202401?wid=5120&hei=2880&fmt=p-jpg&qlt=95&.v=eDVwb1h3eE5DQmx2RnhFenBtbjB4MCsyQVE0K3V5YzhHbWV1TjRxbDUraFY3K0Z2dldtZ0YyMUJMeFdIdnVxRHF2TWlpSzUzejRCZGt2SjJUNGl1VE5rb3YwRE90eklmVkIwdHovcEFheWc3czE5Q2ZmeDA4OWdkZkN0VGliSzM"
            },
            new Product
            {
                Name = "HomePod (2nd Generation)",
                Description = "Full-range sound with spatial awareness and Siri voice assistant.",
                Price = 299.00m,
                ImageUrl = "https://canoonstore.com/wp-content/uploads/2023/08/homepod-select-202210-1024x1024.jpeg"
            },
            new Product
            {
                Name = "Apple TV 4K (128GB)",
                Description = "Wi-Fi + Ethernet, A15 Bionic chip, supports HDR10+ and Dolby Vision.",
                Price = 149.00m,
                ImageUrl = "https://store.storeimages.cdn-apple.com/1/as-images.apple.com/is/apple-tv-4k-hero-select-202210?wid=940&hei=1112&fmt=p-jpg&qlt=95&.v=a3VoZW85YUhreXN3ZFlSUDc3a0tqdU1qeWRTYWRhVU5NM3d6SkhmNzkxTjdKMGdNUjJ3Q0dzSU9tc2pOeGwxbXg4ZHpEbm5XWGdaM3BiNVRDaG55UktNaUdBMSt0VkxKZ2NWelk1alBpUVVXZEdHNUFPR0hYUU12cjI0VlFzM1A"
            }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}
