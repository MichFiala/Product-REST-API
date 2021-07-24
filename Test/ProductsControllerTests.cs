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
using System;

namespace Test
{
	public class ProductsControllerTests : IDisposable
	{
		private readonly DataContext _context;
		public ProductsControllerTests()
		{
			var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

			_context = new DataContext(options);

			_context.Database.EnsureCreated();

			Task.WaitAny(Seed.SeedData(_context));
		}
		[Fact]
		public async Task TestListCount()
		{

			var controller = new ProductsController(_context);

			var actionResult = await controller.GetProducts();

			var okResult = actionResult as OkObjectResult;

			var products = okResult.Value as List<Product>;

			Assert.Equal(17, products.Count);
		}
		[Fact]
		public async Task TestListPage()
		{

			var controller = new ProductsController(_context);

			var actionResult = await controller.GetProductsPaged(new PagingParams());

			var okResult = actionResult as OkObjectResult;

			var products = okResult.Value as List<Product>;

			Assert.Equal(10, products.Count);
		}
		[Fact]
		public async Task TestListEntry()
		{
			var controller = new ProductsController(_context);

			var actionResult = await controller.GetProducts();

			var okResult = actionResult as OkObjectResult;

			var products = okResult.Value as List<Product>;

			Assert.Equal(1, products.FirstOrDefault(x => x.Id == 1)?.Id);
		}
		[Fact]
		public async Task TestDetail()
		{
			var controller = new ProductsController(_context);

			var actionResult = await controller.GetProduct(1);

			var okResult = actionResult as OkObjectResult;

			var product = okResult.Value as Product;

			Assert.Equal(1, product?.Id);
		}

		[Fact]
		public async Task TestDescriptionUpdate()
		{
			var controller = new ProductsController(_context);

			string value = "Description from test";

			var result = await controller.EditProductDescription(1, value);

			var actionResult = await controller.GetProduct(1);

			var okResult = actionResult as OkObjectResult;

			var product = okResult.Value as Product;

			Assert.Equal(value, product?.Description);
		}


		public void Dispose()
		{
			_context.Database.EnsureDeleted();

			_context.Dispose();
		}
	}
}