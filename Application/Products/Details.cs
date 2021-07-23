using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
	public class Details
	{
		private readonly DataContext _dataContext;

		public Details(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public async Task<Result<Product>> Get(int id)
		{
			var product = await _dataContext.Products.FirstOrDefaultAsync(x => x.Id == id);

			return Result<Product>.Success(product);
		}

	}
}