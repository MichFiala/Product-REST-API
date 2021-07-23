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
                    Name = "Produkt - 1",
                    ImgUri = "laptop1.jpg",
                    Price = 14999.9m,
                    Description = "Test description"
                },
                new Product
                {
                    Name = "Produkt - 2",
                    ImgUri = "laptop2.jpg",
                    Price = 28999.0m,
                    Description = "Dell laptop"
                },
                new Product
                {
                    Name = "Produkt - 3",
                    ImgUri = "keyboard.jpg",
                    Price = 1400.0m,
                    Description = null
                },
                new Product
                {
                    Name = "Produkt - 4",
                    ImgUri = "mouse.jpg",
                    Price = 400m,
                    Description = "Verticall mouse"
                },
                new Product
                {
                    Name = "Produkt - 5",
                    ImgUri = "charger.jpg",
                    Price = 580.666666m,
                    Description = null
                },
                new Product
                {
                    Name = "Produkt - 6",
                    ImgUri = "laptop2.jpg",
                    Price = 580.666666m,
                    Description = null
                },
                new Product
                {
                    Name = "Produkt - 7",
                    ImgUri = "mouse.jpg",
                    Price = 800m,
                    Description = null
                },
                new Product
                {
                    Name = "Produkt - 8",
                    ImgUri = "laptop1.jpg",
                    Price = 7000m,
                    Description = null
                },
                new Product
                {
                    Name = "Produkt - 9",
                    ImgUri = "charger.jpg",
                    Price = 336m,
                    Description = null
                },
                new Product
                {
                    Name = "Produkt - 10",
                    ImgUri = "laptop2.jpg",
                    Price = 58000m,
                    Description = null
                },
                new Product
                {
                    Name = "Produkt - 11",
                    ImgUri = "keyboard.jpg",
                    Price = 780m,
                    Description = null
                },
                new Product
                {
                    Name = "Produkt - 12",
                    ImgUri = "laptop2.jpg",
                    Price = 580.666666m,
                    Description = null
                },
                new Product
                {
                    Name = "Produkt - 13",
                    ImgUri = "mouse.jpg",
                    Price = 800m,
                    Description = null
                },
                new Product
                {
                    Name = "Produkt - 14",
                    ImgUri = "laptop1.jpg",
                    Price = 7000m,
                    Description = null
                },
                new Product
                {
                    Name = "Produkt - 15",
                    ImgUri = "charger.jpg",
                    Price = 336m,
                    Description = null
                },
                new Product
                {
                    Name = "Produkt - 16",
                    ImgUri = "laptop2.jpg",
                    Price = 58000m,
                    Description = null
                },
                new Product
                {
                    Name = "Produkt - 17",
                    ImgUri = "keyboard.jpg",
                    Price = 780m,
                    Description = null
                }
			};

			await context.Products.AddRangeAsync(products);
			await context.SaveChangesAsync();
		}
	}
}