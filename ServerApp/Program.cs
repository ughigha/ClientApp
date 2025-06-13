var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient",
        policy => policy.WithOrigins("https://localhost:5001") // Adjust based on front-end URL
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowClient"); // Enable CORS

app.MapGet("/api/productlist", () => new[]
{
    new Product { Id = 101, Name = "Laptop", Price = 1200.99, Stock = 50 },
    new Product { Id = 102, Name = "Monitor", Price = 299.99, Stock = 30 }
});

app.Run();

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}