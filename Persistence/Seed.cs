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
                    ImgUri = "laptop1.jpg",
                    Price = 14999.9m,
                    Description = null
                },
                new Product
                {
                    Name = "Dell",
                    ImgUri = "laptop2.jpg",
                    Price = 28999.0m,
                    Description = "Dell laptop"
                },
                new Product
                {
                    Name = "Keyboard",
                    ImgUri = "keyboard.jpg",
                    Price = 1400.0m,
                    Description = null
                },
                new Product
                {
                    Name = "Mouse",
                    ImgUri = "mouse.jpg",
                    Price = 400m,
                    Description = "Verticall mouse"
                },
                new Product
                {
                    Name = "Charger",
                    ImgUri = "charger.jpg",
                    Price = 580.666666m,
                    Description = null
                },
                new Product
                {
                    Name = "Laptop - 1",
                    ImgUri = "laptop2.jpg",
                    Price = 580.666666m,
                    Description = null
                },
                new Product
                {
                    Name = "Mouse - 1",
                    ImgUri = "mouse.jpg",
                    Price = 800m,
                    Description = null
                },
                new Product
                {
                    Name = "Laptop - 2",
                    ImgUri = "laptop1.jpg",
                    Price = 7000m,
                    Description = null
                },
                new Product
                {
                    Name = "Charger - 1",
                    ImgUri = "charger.jpg",
                    Price = 336m,
                    Description = null
                },
                new Product
                {
                    Name = "Laptop - 3",
                    ImgUri = "laptop2.jpg",
                    Price = 58000m,
                    Description = null
                },
                new Product
                {
                    Name = "Keyboard - 1",
                    ImgUri = "keyboard.jpg",
                    Price = 780m,
                    Description = null
                },
                                new Product
                {
                    Name = "Laptop - 4",
                    ImgUri = "laptop2.jpg",
                    Price = 580.666666m,
                    Description = null
                },
                new Product
                {
                    Name = "Mouse - 2",
                    ImgUri = "mouse.jpg",
                    Price = 800m,
                    Description = null
                },
                new Product
                {
                    Name = "Laptop - 5",
                    ImgUri = "laptop1.jpg",
                    Price = 7000m,
                    Description = null
                },
                new Product
                {
                    Name = "Charger - 3",
                    ImgUri = "charger.jpg",
                    Price = 336m,
                    Description = null
                },
                new Product
                {
                    Name = "Laptop - 6",
                    ImgUri = "laptop2.jpg",
                    Price = 58000m,
                    Description = null
                },
                new Product
                {
                    Name = "Keyboard - 3",
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