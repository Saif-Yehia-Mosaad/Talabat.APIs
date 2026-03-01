using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public class StoreContextSeed
    {
        public async static Task SeedAsync(StoreContext context)
        {
            if (context.ProductBrands.Count() == 0)
            {
                var brandData = File.ReadAllText("../Talabat.Repository/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                if (brandData?.Count() > 0)
                {
                    foreach (var brand in brands)
                    {
                        context.ProductBrands.Add(brand);
                    }
                    await context.SaveChangesAsync();
                } 
            }
            if (context.ProductCategories.Count() == 0)
            {
                var categoriesData = File.ReadAllText("../Talabat.Repository/Data/SeedData/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);

                if (categoriesData?.Count() > 0)
                {
                    foreach (var category in categories)
                    {
                        context.ProductCategories.Add(category);
                    }
                    await context.SaveChangesAsync();
                }
            }
            if (context.Products.Count() == 0)
            {
                var productsData = File.ReadAllText("../Talabat.Repository/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (productsData?.Count() > 0)
                {
                    foreach (var product in products)
                    {
                        context.Products.Add(product);
                    }
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
