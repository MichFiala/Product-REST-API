using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
	public class List
	{
		private readonly DataContext _dataContext;
		public List(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public async Task<Result<List<Product>>> Get(int? step = null, int? take = null)
		{
			List<Product> products = null;

			if (step != null && take != null)
			{
				products = await _dataContext.Products
							.OrderBy(x => x.Name)
							.Skip(step.Value * take.Value)
							.Take(take.Value).ToListAsync();
			}
			else
			{
				products = await _dataContext.Products.ToListAsync();
			}

			return Result<List<Product>>.Success(products);
		}
	}
}