// using ECommerce.Infrastructure;
// using Microsoft.EntityFrameworkCore;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// // Add CORS
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll", policy =>
//     {
//         policy.AllowAnyOrigin()
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//     });
// });

// // Add DbContext with in-memory database for development
// builder.Services.AddDbContext<ECommerceDbContext>(options =>
//     options.UseInMemoryDatabase("ECommerceDb"));

// var app = builder.Build();

// // Seed data
// using (var scope = app.Services.CreateScope())
// {
//     var context = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();
//     context.Database.EnsureCreated();
//     DataSeeder.SeedProducts(context);
// }

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// // Use CORS
// app.UseCors("AllowAll");

// // Map controllers
// app.MapControllers();

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
// using Microsoft.EntityFrameworkCore;
//   using ECommerce.Infrastructure;

//   var builder = WebApplication.CreateBuilder(args);

//   // Add services to the container.
//   builder.Services.AddControllers();
//   builder.Services.AddEndpointsApiExplorer();
//   builder.Services.AddSwaggerGen();

//   // Add CORS
//   builder.Services.AddCors(options =>
//   {
//       options.AddPolicy("AllowAll", policy =>
//       {
//           policy.AllowAnyOrigin()
//                 .AllowAnyMethod()
//                 .AllowAnyHeader();
//       });
//   });

//   // Add DbContext with SQL Server
//   builder.Services.AddDbContext<ECommerceDbContext>(options =>
//       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//   var app = builder.Build();

//   // Seed data (optional, move to migrations if preferred)
//   using (var scope = app.Services.CreateScope())
//   {
//       var context = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();
//       context.Database.EnsureCreated(); // Use Migrate() with migrations instead
//       // DataSeeder.SeedProducts(context); // Comment out or remove if using migrations
//   }

//   // Configure the HTTP request pipeline.
//   if (app.Environment.IsDevelopment())
//   {
//       app.UseSwagger();
//       app.UseSwaggerUI();
//   }

//   app.UseHttpsRedirection();

//   // Use CORS
//   app.UseCors("AllowAll");

//   // Map controllers
//   app.MapControllers();

//   app.Run();

//   // Remove WeatherForecast if not needed
//   // record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//   // {
//   //     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//   // }
// using Microsoft.EntityFrameworkCore;
//      using ECommerce.Infrastructure;

//      var builder = WebApplication.CreateBuilder(args);

//      // Add services to the container.
//      builder.Services.AddControllers();
//      builder.Services.AddEndpointsApiExplorer();
//      builder.Services.AddSwaggerGen();

//      // Add CORS
//      builder.Services.AddCors(options =>
//      {
//          options.AddPolicy("AllowAll", policy =>
//          {
//              policy.AllowAnyOrigin()
//                    .AllowAnyMethod()
//                    .AllowAnyHeader();
//          });
//      });

//      // Add DbContext with SQL Server
//      builder.Services.AddDbContext<ECommerceDbContext>(options =>
//          options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//      var app = builder.Build();

//      // Apply migrations
//      using (var scope = app.Services.CreateScope())
//      {
//          var context = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();
//          context.Database.Migrate(); // Use Migrate() instead of EnsureCreated
//          // Comment out DataSeeder if not needed with migrations
//          // DataSeeder.SeedProducts(context);
//      }

//      // Configure the HTTP request pipeline.
//      if (app.Environment.IsDevelopment())
//      {
//          app.UseSwagger();
//          app.UseSwaggerUI();
//      }

//      app.UseHttpsRedirection();

//      // Use CORS
//      app.UseCors("AllowAll");

//      // Map controllers
//      app.MapControllers();

//      app.Run();

//      // Remove WeatherForecast if not needed
//      // record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
//      // {
//      //     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//      // }
using Microsoft.EntityFrameworkCore;
     using ECommerce.Infrastructure;

     var builder = WebApplication.CreateBuilder(args);

     // Add services to the container.
     builder.Services.AddControllers();
     builder.Services.AddEndpointsApiExplorer();
     builder.Services.AddSwaggerGen();

     // Add CORS
     builder.Services.AddCors(options =>
     {
         options.AddPolicy("AllowAll", policy =>
         {
             policy.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
         });
     });

     // Add DbContext with SQL Server
     builder.Services.AddDbContext<ECommerceDbContext>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

     var app = builder.Build();

     // Apply migrations
     using (var scope = app.Services.CreateScope())
     {
         var context = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();
         context.Database.Migrate();
     }

     // Configure the HTTP request pipeline.
     if (app.Environment.IsDevelopment())
     {
         app.UseSwagger();
         app.UseSwaggerUI();
     }

     app.UseHttpsRedirection();

     // Use CORS
     app.UseCors("AllowAll");

     // Map controllers
     app.MapControllers();

     app.Run();