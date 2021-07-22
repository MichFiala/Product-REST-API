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
		public async Task<Result<Unit>> Handle(Product Product, DataContext DataContext)
		{
			var product = await DataContext.Products.FindAsync(Product.Id);

			if (product == null) return null;
			// Updating only description
			product.Description = Product.Description;

			var result = await DataContext.SaveChangesAsync() > 0;

			return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to update product");
		}

	}
}