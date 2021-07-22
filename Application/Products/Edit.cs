using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Products
{
	public class Edit
	{
		public class Command : IRequest<Result<Unit>>
		{
			public Product Product { get; set; }
		}

		public class Handler : IRequestHandler<Command, Result<Unit>>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
			{
				var product = await _context.Products.FindAsync(request.Product.Id);

				if (product == null) return null;
				// Updating only description
				product.Description = request.Product.Description;

				var result = await _context.SaveChangesAsync() > 0;

				return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to update product");
			}
		}
	}
}