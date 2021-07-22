using Microsoft.EntityFrameworkCore;
using Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions options) : base(options) { }

		public virtual DbSet<Product> Products { get; set; }
	}
}