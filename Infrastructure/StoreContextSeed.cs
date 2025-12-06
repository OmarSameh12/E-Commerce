using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public static class StoreContextSeed
    {
        public static async Task seedAsync(StoreDbContext context,ILoggerFactory loggerFactory) {
			try
			{
				if (context.ProductBrands != null && !context.ProductBrands.Any()) {
					var bransfile =  File.ReadAllText("../Infrastructure/seedData/brands.json");
					var brands= JsonSerializer.Deserialize<List<ProductBrand>>(bransfile);

					foreach (var brand in brands)
						await context.ProductBrands.AddAsync(brand);	

					await context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{

				var logger=loggerFactory.CreateLogger(typeof(StoreContextSeed));
				logger.LogError(ex.Message);
			}
				try
			{
				if (context.ProductTypes != null && !context.ProductTypes.Any()) {
					var productfile =  File.ReadAllText("../Infrastructure/seedData/types.json");
					var productTypes= JsonSerializer.Deserialize<List<ProductType>>(productfile);

					foreach (var p in productTypes)
						await context.ProductTypes.AddAsync(p);	

					await context.SaveChangesAsync();
				}
			}
			catch (Exception)
			{

				throw;
			}
				try
			{
				if (context.Products != null && !context.Products.Any()) {
					var productsFile =  File.ReadAllText("../Infrastructure/seedData/products.json");
					var products= JsonSerializer.Deserialize<List<Product>>(productsFile);

					foreach (var p in products)
						await context.Products.AddAsync(p);	

					await context.SaveChangesAsync();
				}
			}
			catch (Exception)
			{

				throw;
			}
				try
			{
				if (context.deliveryMethods != null && !context.deliveryMethods.Any()) {
					var deliveryMethodsDataText =  File.ReadAllText("../Infrastructure/seedData/delivery.json");
					var deliveryMethods= JsonSerializer.Deserialize<List<DeliverMethod>>(deliveryMethodsDataText);

					foreach (var p in deliveryMethods)
						await context.deliveryMethods.AddAsync(p);	

					await context.SaveChangesAsync();
				}
			}
			catch (Exception)
			{

				throw;
			}


        }


    }
}
