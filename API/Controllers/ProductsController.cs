using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
		[HttpGet]
		public async Task<List<string>> GetProducts()
		{

			return await Task.Run(() => { return new List<string>() { "p", "p1" }; });
			// return HandleResult(await Mediator.Send(new List.Query()));
		}
	}
}