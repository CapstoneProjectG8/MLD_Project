using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using Project_MLD.Utils.PasswordHash;
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
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public AccountController(IConfiguration configuration,
            IAccountRepository repository,
            MldDatabaseContext context,
            IMapper mapper,
            IPasswordHasher passwordHasher)
        {
            _config = configuration;
            _context = context;
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] AccountDTO accountLogin)
        {
            var acc = Authenticate(accountLogin.Username, accountLogin.Password);
            if (acc != null)
            {
                var token = Generate(acc);
                if (token != null)
                {
                    return Ok(token);
                }
                return BadRequest("Token cannot create");
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
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Account.Role.RoleName)
            };

            var token = new JwtSecurityToken(
                claims: claims,
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(string username, string password)
        {
            var currentAccount = _context.Users
                .Include(x => x.Account).ThenInclude(account => account.Role)
                .FirstOrDefault(x => x.Account.Username == username.ToLower());
            if (currentAccount != null)
            {
                bool result = _passwordHasher.VerifyPassword(currentAccount.Account.Password, password);
                if (result)
                {
                    return currentAccount;
                }
                return null;
            }
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
                        + " " + accountClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value
                         + " " + accountClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value);
            }
            return null;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAllAccount()
        {
            var acc = await _repository.GetAllAccounts();
            return Ok(acc);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccountById(int id)
        {
            var exAcc = await _repository.GetAccountById(id);
            if (exAcc == null)
            {
                return NotFound();
            }

            return Ok(exAcc);
        }

        [HttpPost]
        public async Task<ActionResult<Account>> AddAccount(AccountDTO acc)
        {
            //Check exist
            var existAccount = _repository.GetAccountByUsername(acc.Username);
            if (existAccount != null)
            {
                return BadRequest("Account Exist");
            }
            acc.Active = true;
            acc.CreatedBy = "ADMIN";
            acc.CreatedDate = DateOnly.FromDateTime(DateTime.Now);
            acc.Password = _passwordHasher.Hash(acc.Password);

            var account = _mapper.Map<Account>(acc);

            var accountCreated = await _repository.AddAccount(account);

            return Ok(accountCreated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var result = await _repository.DeleteAccount(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Account acc)
        {
            if (id != acc.AccountId)
            {
                return BadRequest();
            }

            var result = await _repository.UpdateAccount(acc);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
