using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ProductGrpc.Protos;
using ProductGrpc.Service.Data;

namespace ProductGrpc.Service.Services
{
	public class ProductService : ProductProtoService.ProductProtoServiceBase
	{
		private readonly ProductsContext _productContext;
		private readonly ILogger<ProductService> _logger;

		public ProductService(ILogger<ProductService> logger, ProductsContext productContext)
		{
			_logger = logger;
			_productContext = productContext;
		}

		public override Task<Empty> Test(Empty request, ServerCallContext context)
		{
			return base.Test(request, context);
		}

		public override async Task<ProductModel> GetProduct(GetProductRequest request, ServerCallContext context)
		{	
			var product = await _productContext.Products.FindAsync(request.ProductId);

			if (product == null) 
			{
				// throw an rpc exception
			}

			var productModel = new ProductModel
			{
				ProductId = product.ProductId,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				Status = ProductStatus.Instock,
				CreatedTime = Timestamp
				.FromDateTime(product.CreatedTime)
			};

			return productModel;
			//return base.GetProduct(request, context);
		}
	}
}
