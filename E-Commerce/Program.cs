using Core;
using Core.IdentityDbContext;
using E_Commerce.Extentions;
using E_Commerce.HandleResponses;
using E_Commerce.Helper;
using E_Commerce.Middlewares;
using Infrastructure;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Services.ProductServices;
using Services.Services.ProductServices.Dto;
using StackExchange.Redis;

namespace E_Commerce
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<StoreDbContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
              builder.Services.AddDbContext<AppIdentityDbContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });

            builder.Services.AddApplicationService();
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddSingleton<IConnectionMultiplexer>(config => {
                var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);            
            });
            var app = builder.Build();
           await ApplySeeding.ApplySeedingAsync(app);
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                    app.UseMiddleware<ExceptionMiddleware>();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}