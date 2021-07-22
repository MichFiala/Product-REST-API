using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class List
    {
		public class Query : IRequest<Result<List<Product>>> 
		{ 
			public int? Take { get; set; }

			public int? Step { get; set; }
		}

        public class Handler : IRequestHandler<Query, Result<List<Product>>>
		{
			private readonly DataContext _context;
			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Result<List<Product>>> Handle(Query request, CancellationToken cancellationToken)
			{
				List<Product> products = null;

				if(request.Step != null && request.Take != null)
				{
					products = await _context.Products
								.OrderBy(x => x.Price)
								.Skip(request.Step.Value * request.Take.Value)
								.Take(request.Take.Value).ToListAsync();
				}
				else
				{
					products = await _context.Products.ToListAsync();
				}

				return Result<List<Product>>.Success(products);
			}
		}
	}
}