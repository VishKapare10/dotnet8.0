using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly string _secretKey;

    public AuthController()
    {
        // Your custom secret key
        _secretKey = "this is my custom Secret key for authentication"; // Ensure this is at least 32 bytes (256 bits)
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        // Simulate user validation (replace with real validation)
        if (model.Username == "test" && model.Password == "password") // Example credentials
        {
            var token = GenerateToken(model.Username);
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }

    private string GenerateToken(string username)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username)
        };

        // Convert the key to bytes
        var keyBytes = Encoding.UTF8.GetBytes(_secretKey);
        var creds = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "yourdomain.com", // Update to your actual issuer
            audience: "yourdomain.com", // Update to your actual audience
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}
