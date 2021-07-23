using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
	public class ProductsController : BaseApiController
	{
		private readonly DataContext _dataContext;

		public ProductsController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		[HttpGet]
		public async Task<IActionResult> GetProducts()
		{
			return HandleResult(await new List(_dataContext).Get());
		}
		[HttpGet("{page}/{take?}")]
		[MapToApiVersion("2.0")]
		public async Task<IActionResult> GetProducts(int page, int? take = 10)
		{
			return HandleResult(await new List(_dataContext).Get(page, take));
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetProduct(int id)
		{
			return HandleResult(await new Details(_dataContext).Get(id));
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> EditProduct(int id, string description)
		{
			Product product = new Product
			{
				Id = id,
				Description = description
			};

			return HandleResult(await new Edit(_dataContext).Handle(product));
		}
	}
}