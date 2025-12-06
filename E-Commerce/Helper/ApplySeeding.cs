using Core;
using Core.IdentityEntities;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Helper
{
    public static class ApplySeeding
    {

        public static async Task ApplySeedingAsync(WebApplication app) {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<StoreDbContext>();
                    await context.Database.MigrateAsync();
                    await StoreContextSeed.seedAsync(context, loggerFactory);

                    var userManager = services.GetRequiredService<UserManager<AppUser>>();
                       await AppIdentityContextSeed.SeedUserAsync(userManager);
                
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger(typeof(StoreContextSeed));
                    logger.LogError(ex.Message);
                }
            }

        }


    }
}
