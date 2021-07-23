using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using Persistence;

namespace Application.Products
{
	public class Edit
	{
		private readonly DataContext _dataContext;
		public Edit(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<Result<bool?>> Handle(Product product)
		{
			var productEntity = await _dataContext.Products.FindAsync(product.Id);

			if (productEntity == null) return null;
			// Updating only description
			productEntity.Description = product.Description;

			var result = await _dataContext.SaveChangesAsync() > 0;

			return result ? Result<bool?>.Success(true) : Result<bool?>.Failure("Failed to update product");
		}

	}
}