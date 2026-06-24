using InventoryManagementAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Model;
using Microsoft.Identity.Client;
using BCrypt.Net;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    [HttpPost("login")]

    public IActionResult Login(LoginRequest request)
    {
        var user = _context.Users
            .FirstOrDefault(x => x.Username == request.Username && x.Password == request.Password);

        if (user == null)
        {
            return Unauthorized("Invalid credentials");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"])
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(new { token = jwt });
    }


    [HttpPost ("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var user = _context.Users
            .FirstOrDefault(x => x.Username == request.Username);

        if(user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {

            return Unauthorized("Invalid credentials");
        }

        // this is hash password 

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var User = new User
        {
            Username = request.Username,
            Password = hashedPassword,
            Role = request.Role
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok("User register successfully");
    }
}