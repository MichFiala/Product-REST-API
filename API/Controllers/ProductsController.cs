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
		public async Task<List<Product>> GetProducts()
		{
			return await Mediator.Send(new List.Query());
		}
		[HttpGet("{id}")]
		public async Task<Product> GetProduct(int id)
		{
			return await Mediator.Send(new Details.Query { Id = id });
		}
	}
}