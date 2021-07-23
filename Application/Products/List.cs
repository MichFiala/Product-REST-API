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
		public async Task<Result<PagedList<Product>>> GetByPaging(PagingParams pagingParams)
		{
			var products = _dataContext.Products.OrderBy(x => x.Id).AsQueryable();

			return Result<PagedList<Product>>.Success(
				await PagedList<Product>.CreateAsync(products, pagingParams.PageNumber, pagingParams.PageSize)
			);
		}

		public async Task<Result<List<Product>>> Get()
		{
			var products = await _dataContext.Products.ToListAsync();

			return Result<List<Product>>.Success(products);
		}
	}
}