using ProductGrpc.Service.Models;

namespace ProductGrpc.Service.Data
{
	public class ProductsContextSeed
	{
		public static void seedAsync(ProductsContext productsContext)
		{
			if (!productsContext.Products.Any())
			{
				productsContext.Products.AddRange(new List<Product>
				{
					new Product()
					{
						ProductId = 1,
						Name = "Mi10T",
						Description ="New Xiaomi Phone Mi10T",
						Price = 699,
						Status = ProductStatus.INSTOCK,
						CreatedTime = DateTime.UtcNow,
					},
					new Product()
					{
						ProductId = 2,
						Name = "P40",
						Description ="New Huwaei Pone P40",
						Price = 899,
						Status = ProductStatus.INSTOCK,
						CreatedTime = DateTime.UtcNow,
					},
					new Product()
					{
						ProductId = 3,
						Name = "A50",
						Description ="New Samsumg Phone A50",
						Price = 399,
						Status = ProductStatus.INSTOCK,
						CreatedTime = DateTime.UtcNow,
					}
				});
				productsContext.SaveChanges();
			}
		}
	}
}
