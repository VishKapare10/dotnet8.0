var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Use the custom middleware
app.UseMiddleware<RequestTimingMiddleware>();

app.MapGet("/", () => "Hello, World!");

app.Run();
