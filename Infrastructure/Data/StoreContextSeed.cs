using Core.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
			try
			{
                //add Brands to database
                if (!context.ProductBrands.Any())
				{
					var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
					var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    _ = brands ?? throw new ArgumentNullException(nameof(brands));
                    foreach (var item in brands)
                    {
                        await context.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }

                //add Types to database
                if (!context.ProductTypes.Any())
                {
                    var typeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);

                    _ = types ?? throw new ArgumentNullException(nameof(types));
                    foreach (var item in types)
                    {
                        await context.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }

                //add Products to database
                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    _ = products ?? throw new ArgumentNullException(nameof(products));
                    foreach (var item in products)
                    {
                        await context.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
			catch (Exception ex)
			{
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
			}
        }
    }
}
