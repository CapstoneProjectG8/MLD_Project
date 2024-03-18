using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project_MLD.Models;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _config;
        private readonly MldDatabaseContext _context;
        public AccountController(IConfiguration configuration, MldDatabaseContext context)
        {
            _config = configuration;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Account accountLogin)
        {
            var acc = Authenticate(accountLogin.Username,accountLogin.Password);
            if (acc != null)
            {
                var token = Generate(acc);
                if (token != null)
                {
                    return Ok(token);
                }
                return BadRequest("ABCDEFGH");
            }
            return NotFound("Account Not Found");
        }

        [HttpGet("CheckAuthenciation")]
        [Authorize(Roles = "Admin")]
        public IActionResult Check()
        {
            var s = GetCurrentAccount();
            if (s != null)
            {
                return Ok(s);
            }
            return NotFound();
        }
        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.FullName),
                new Claim(ClaimTypes.Role, user.Account.Role.RoleName)
            };

            var token = new JwtSecurityToken(
                claims: claims,
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(string username, string password)
        {
            var currentAccount = _context.Users
                .Include(x => x.Account)
                .ThenInclude(account => account.Role)
                .FirstOrDefault(x =>
                x.Account.Username == username.ToLower() &&
                x.Account.Password == password);
            if (currentAccount != null)
                return currentAccount;
            return null;
        }

        private string GetCurrentAccount()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var accountClaims = identity.Claims;
                return (
                        accountClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value
                        + " " + accountClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value);
            }
            return null;
        }
    }
}
