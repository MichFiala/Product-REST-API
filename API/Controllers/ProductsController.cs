using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Products;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class ProductsController : BaseApiController
	{
		[HttpGet]
		public async Task<IActionResult> GetProducts()
		{
			return HandleResult(await Mediator.Send(new List.Query()));
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetProduct(int id)
		{
			return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> EditProduct(int id, string description)
		{
			Product product = new Product
			{
				Id = id,
				Description = description
			};

			return HandleResult(await Mediator.Send(new Edit.Command { Product = product }));
		}
	}
}