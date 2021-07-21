using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
	public class Seed
	{
		public static async Task SeedData(DataContext context)
		{
			if (context.Products.Any()) return;

			var products = new List<Product>()
			{
                new Product
                {
                    Name = "HP",
                    ImgUri = "hp.png",
                    Price = 14999.9m,
                    Description = null
                },
                new Product
                {
                    Name = "Dell",
                    ImgUri = "dell.png",
                    Price = 28999.0m,
                    Description = "Dell laptop"
                },
                new Product
                {
                    Name = "Keyboard",
                    ImgUri = "kb.png",
                    Price = 1400.0m,
                    Description = null
                },
                new Product
                {
                    Name = "Mouse",
                    ImgUri = "mouse.png",
                    Price = 400m,
                    Description = "Verticall mouse"
                },
                new Product
                {
                    Name = "Charger",
                    ImgUri = "charger.jpg",
                    Price = 580.666666m,
                    Description = null
                }
			};

			await context.Products.AddRangeAsync(products);
			await context.SaveChangesAsync();
		}
	}
}