
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