using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLogging();

var app = builder.Build();

// Use the custom middleware
app.UseMiddleware<RequestTimingMiddleware>();

// Define a simple endpoint
app.MapGet("/", () => "Hello, World!");

app.Run();
