using FiltersDemo.Filters;

var builder = WebApplication.CreateBuilder(args);

// Register filters
builder.Services.AddScoped<CustomActionFilter>();
builder.Services.AddScoped<CustomResultFilter>();
builder.Services.AddScoped<CustomExceptionFilter>();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapControllers();
app.Run();
