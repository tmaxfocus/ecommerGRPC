using Microsoft.EntityFrameworkCore;
using ProductGrpc.Service.Data;
using ProductGrpc.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<ProductsContext>(options => options.UseInMemoryDatabase("Products"));

var serviceProvider = builder.Services.BuildServiceProvider();
var myService = serviceProvider.GetService<ProductsContext>();
ProductsContextSeed.seedAsync(myService);
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
