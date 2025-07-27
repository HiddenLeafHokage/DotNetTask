using Microsoft.EntityFrameworkCore.Migrations;

     #nullable disable

     namespace ECommerce.Infrastructure.Migrations
     {
         /// <inheritdoc />
         public partial class SeedInitialProducts : Migration
         {
             /// <inheritdoc />
             protected override void Up(MigrationBuilder migrationBuilder)
             {
                 // Check if data exists to avoid duplicates
                 migrationBuilder.Sql(@"
                     IF NOT EXISTS (SELECT 1 FROM Products WHERE Name = 'MacBook Pro M3 Max')
                     BEGIN
                         INSERT INTO Products (Name, Description, Price, ImageUrl)
                         VALUES 
                             ('MacBook Pro M3 Max', '16-inch MacBook Pro with M3 Max chip, 64GB RAM, 2TB SSD.', 3999.99, 'https://www.istore.com.ng/cdn/shop/files/MacBook_Pro_16_in_M3_Pro_Max_Space_Black_PDP_Image_Position-1__WWEN_de97454c-5c57-46f3-9e95-52ae7c896d93_5000x.jpg?v=1700852370'),
                             ('iPhone 15 Pro Max', '6.7-inch Super Retina XDR display, A17 Pro, 256GB, Natural Titanium.', 1199.00, 'https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-15-pro-finish-select-202309-6-1inch?wid=5120&hei=2880&fmt=jpeg&qlt=80&.v=1692923760803'),
                             ('iPad Pro 13-inch (M4)', '13-inch Ultra Retina XDR display, M4 chip, 512GB, Wi-Fi.', 1499.00, 'https://cdsassets.apple.com/live/7WUAS350/images/tech-specs/ipad-pro-11-inch-13-inch.png'),
                             ('AirPods Pro (2nd Gen, USB-C)', 'Spatial audio, Active Noise Cancellation, MagSafe case with USB-C.', 249.00, 'https://imgs.search.brave.com/uMYM55DOgxnoSqUUJy99WtLQNhH2RQ1I6HqPeAkGdag/rs:fit:860:0:0:0/g:ce/aHR0cHM6Ly9tLm1l/ZGlhLWFtYXpvbi5j/b20vaW1hZ2VzL0kv/NDFlbENNWHdha0wu/anBn'),
                             ('Apple Watch Ultra 2', '49mm Titanium Case with Alpine Loop, S9 SiP, 36-hour battery.', 799.00, 'https://store.storeimages.cdn-apple.com/1/as-images.apple.com/is/ultra-case-unselect-gallery-1-202409?wid=5120&hei=3280&fmt=p-jpg&qlt=80&.v=aTVJSEliNW9jb25zalBlTm16VmMxcWpkNHRJWDMzcTg3NWRxV0pydTcvSUxMekYrWHVDVjVJT1ZDYVlkUjdVUnc2NytHaDA2aFdROEtrekNxcXV6T3VmenhDNGxXRVM5RSs4RlRpMXdYVWhCUjJHK0dyT0t2cDF1RTlMancyMG8'),
                             ('Apple Vision Pro', 'Spatial computer with dual 4K micro‑OLED displays and eye tracking.', 3499.00, 'https://store.storeimages.cdn-apple.com/1/as-images.apple.com/is/vision-pro-gallery-measure-dual-loop-202401?wid=5120&hei=2880&fmt=p-jpg&qlt=95&.v=eDVwb1h3eE5DQmx2RnhFenBtbjB4MCsyQVE0K3V5YzhHbWV1TjRxbDUraFY3K0Z2dldtZ0YyMUJMeFdIdnVxRHF2TWlpSzUzejRCZGt2SjJUNGl1VE5rb3YwRE90eklmVkIwdHovcEFheWc3czE5Q2ZmeDA4OWdkZkN0VGliSzM'),
                             ('HomePod (2nd Generation)', 'Full-range sound with spatial awareness and Siri voice assistant.', 299.00, 'https://canoonstore.com/wp-content/uploads/2023/08/homepod-select-202210-1024x1024.jpeg'),
                             ('Apple TV 4K (128GB)', 'Wi-Fi + Ethernet, A15 Bionic chip, supports HDR10+ and Dolby Vision.', 149.00, 'https://store.storeimages.cdn-apple.com/1/as-images.apple.com/is/apple-tv-4k-hero-select-202210?wid=940&hei=1112&fmt=p-jpg&qlt=95&.v=a3VoZW85YUhreXN3ZFlSUDc3a0tqdU1qeWRTYWRhVU5NM3d6SkhmNzkxTjdKMGdNUjJ3Q0dzSU9tc2pOeGwxbXg4ZHpEbm5XWGdaM3BiNVRDaG55UktNaUdBMSt0VkxKZ2NWelk1alBpUVVXZEdHNUFPR0hYUU12cjI0VlFzM1A')
                     END");
             }

             /// <inheritdoc />
             protected override void Down(MigrationBuilder migrationBuilder)
             {
                 migrationBuilder.Sql(@"
                     DELETE FROM Products
                     WHERE Name IN (
                         'MacBook Pro M3 Max', 'iPhone 15 Pro Max', 'iPad Pro 13-inch (M4)',
                         'AirPods Pro (2nd Gen, USB-C)', 'Apple Watch Ultra 2', 'Apple Vision Pro',
                         'HomePod (2nd Generation)', 'Apple TV 4K (128GB)'
                     )");
             }
         }
     }