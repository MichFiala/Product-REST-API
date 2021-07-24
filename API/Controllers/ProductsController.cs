using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core;
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
		[HttpGet("paged")]
		[MapToApiVersion("2.0")]
		public async Task<IActionResult> GetProductsPaged([FromQuery]PagingParams pagingParams)
		{
			return HandlePagedResult(await new List(_dataContext).GetByPaging(pagingParams));
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetProduct(int id)
		{
			return HandleResult(await new Details(_dataContext).Get(id));
		}
		[HttpPut("{id}/description")]
		public async Task<IActionResult> EditProductDescription(int id, string description)
		{
			Product product = new Product
			{
				Id = id,
				Description = description
			};

			return HandleResult(await new Edit(_dataContext).Handle(product));
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> EditProduct(int id, Product product)
		{
			product.Id = id;

			return HandleResult(await new Edit(_dataContext).Handle(product));
		}
	}
}