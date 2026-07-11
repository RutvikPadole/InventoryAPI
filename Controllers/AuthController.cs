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
using Microsoft.AspNetCore.Authorization;


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
        if (user == null || user.Password != request.Password)
        {

            return Unauthorized("Invalid credentials");
        }


        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role,"Admin")
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

        return Ok(new { token = jwt });
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

   

}