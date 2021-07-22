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
		[HttpGet("{page}/{take?}")]
		[MapToApiVersion("2.0")]
		public async Task<IActionResult> GetProducts(int page, int? take = 10)
		{
			return HandleResult(await Mediator.Send(new List.Query{ Step = page, Take = take}));
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