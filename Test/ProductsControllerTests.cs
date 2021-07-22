using Xunit;
using API.Controllers;
using FakeItEasy;
using Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Application.Core;
using Microsoft.AspNetCore.Mvc;

namespace Test
{
	public class ProductsControllerTests
	{
		[Fact]
		public async Task TestList()
		{

			var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options;

			var context = new DataContext(options);

			await Seed.SeedData(context);

			var controller = new ProductsController(context);

			var actionResult = await controller.GetProducts();

			var okResult = actionResult as OkObjectResult;

			var products = okResult.Value as List<Product>;

			Assert.Equal(5, products.Count);
		}
	}
}