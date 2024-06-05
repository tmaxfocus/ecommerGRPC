using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using ProductGrpc.Service.Models;

namespace ProductGrpc.Service.Data
{
	public class ProductsContext : DbContext
	{
		public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
		{
		
		}

		public DbSet<Product> Products { get; set; }
	}
}