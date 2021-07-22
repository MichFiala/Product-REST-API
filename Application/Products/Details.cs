using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
	public class Details
	{
		public async Task<Result<Product>> Get(int Id, DataContext DataContext)
		{
			var product = await DataContext.Products.FirstOrDefaultAsync(x => x.Id == Id);

			return Result<Product>.Success(product);
		}

	}
}