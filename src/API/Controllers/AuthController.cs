using BCrypt.Net;
using InventoryManagementAPI.src.Application.DTOs;
using InventoryManagementAPI.src.Domain;
using InventoryManagementAPI.src.Domain.Model;
using InventoryManagementAPI.src.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


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
            .FirstOrDefault(x => x.Username == request.Username);   

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {

            return Unauthorized("Invalid credentials");
        }


        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("THIS_IS_MY_SECRET_KEY_12345_ABCDEFG"));

        var token = new JwtSecurityToken(
       issuer: "MyApp",
       audience: "MyAppUsers",
       claims: claims,
       expires: DateTime.Now.AddHours(1),
       signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
   );

        string jwt = new JwtSecurityTokenHandler().WriteToken(token);

        var refreshToken = Guid.NewGuid().ToString();

        _context.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            UserId = user.Id,
            ExpiryDate = DateTime.Now.AddDays(7)
        });

        _context.SaveChanges();

        return Ok(new { token = jwt,
            refreshToken = refreshToken
        });
    }


    [HttpPost ("register")]
    public IActionResult Register([FromBody]RegisterRequest request)
    {
        var existingUser = _context.Users
            .FirstOrDefault(x => x.Username == request.Username);

        if (existingUser != null)
        {
            return BadRequest("User already exists");
        }

        // this is hash password 

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var User = new User
        {
            Username = request.Username,
            Password = hashedPassword,
            Role = request.Role
        };

        _context.Users.Add(User);
        _context.SaveChanges();

        return Ok("User register successfully");
    }

    [HttpPost("refresh")]
    public IActionResult Refresh([FromBody] string refreshToken)
    {
        var token = _context.RefreshTokens
            .FirstOrDefault(x => x.Token == refreshToken);

        if (token == null || token.ExpiryDate < DateTime.Now)
            return Unauthorized();

        var user = _context.Users.Find(token.UserId);

        var claims = new[]
        {
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Role, user.Role)
    };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("YOUR_SECRET_KEY"));

        var newJwt = new JwtSecurityTokenHandler().WriteToken(
            new JwtSecurityToken(
                issuer: "MyApp",
                audience: "MyAppUsers",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            )
        );

        return Ok(new { token = newJwt });
    }



}