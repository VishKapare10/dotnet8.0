using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Your custom secret key
var secretKey = "this is my custom Secret key for authentication"; // Make sure this is at least 32 characters for HS256

// Add services to the container.
builder.Services.AddControllers();

// Configure JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var keyBytes = Encoding.UTF8.GetBytes(secretKey);
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "yourdomain.com", // Update to your actual issuer
        ValidAudience = "yourdomain.com", // Update to your actual audience
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes) // Use the byte array for the signing key
    };
});

var app = builder.Build();

// Use Authentication and Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
