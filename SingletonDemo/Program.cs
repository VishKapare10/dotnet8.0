var builder = WebApplication.CreateBuilder(args);

// Register LoggerService as a Singleton
builder.Services.AddSingleton<LoggerService>();

var app = builder.Build();

// Basic route for testing
app.MapGet("/", (LoggerService logger) =>
{
    logger.Log("Home route was hit.");
    return "Hello, World!";
});

// Another route to test logging
app.MapGet("/log", (LoggerService logger) =>
{
    logger.Log("Log route was hit.");
    return "Log message has been recorded!";
});

app.Run();
