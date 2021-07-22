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
		public async Task<Result<List<Product>>> Get(DataContext DataContext, int? Step = null, int? Take = null)
		{
			List<Product> products = null;

			if(Step != null && Take != null)
			{
				products = await DataContext.Products
							.OrderBy(x => x.Name)
							.Skip(Step.Value * Take.Value)
							.Take(Take.Value).ToListAsync();
			}
			else
			{
				products = await  DataContext.Products.ToListAsync();
			}

			return Result<List<Product>>.Success(products);
		}
	}
}