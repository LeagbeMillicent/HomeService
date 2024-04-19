using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HomeService.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HomeService.API.Controllers;
[Route("/api/[controller]")]
[ApiController]
public class LoginController : Controller
{
    private IConfiguration _config;
    public LoginController(IConfiguration config)
    {
        _config = config;
    }

    private UserModel AuthenticateUser(UserModel user)
    {
        UserModel _user = null;
        if(user.Username == "admin" && user.Password == "12345")
            _user = new UserModel { Username = "Milli" };
        return _user;
    }


    private string GenerateToken(UserModel user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            expires: DateTime.Now.AddDays(7),
            signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserModel user)
    {
        IActionResult result = Unauthorized();
        var user_ = AuthenticateUser(user);
        if (user_ == null)
        {
            var token = GenerateToken(user_);
            result = Ok(new { token = token });
        }   
        return result;
    }
}