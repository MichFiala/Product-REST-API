using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Products
{
    public class Edit
    {
        public class Command : IRequest<Unit>
		{
			public Product Product { get; set; }
		}

        public class Handler : IRequestHandler<Command, Unit>
		{
			private readonly DataContext _context;

			public Handler(DataContext context)
			{
				_context = context;
			}

			public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
			{
				var product = await _context.Products.FindAsync(request.Product.Id);

				if(product == null) return Unit.Value;
                // Updating only description
				product.Description = request.Product.Description;

				var result = await _context.SaveChangesAsync() > 0;

				return Unit.Value;
			}
		}
    }
}