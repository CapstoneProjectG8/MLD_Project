using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using Project_MLD.Utils.GenerateCode;
using Project_MLD.Utils.GmailSender;
using Project_MLD.Utils.PasswordHash;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;


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
        private readonly IEmailSender _emailSender;
        private readonly IMailBody _mailBody;
        private static string codeGenerate = "";

        public AccountController(IConfiguration configuration, IAccountRepository repository,
            MldDatabaseContext context, IMapper mapper, IPasswordHasher passwordHasher,
            IEmailSender emailSender, IMailBody mailBody)
        {
            _config = configuration;
            _context = context;
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _emailSender = emailSender;
            _mailBody = mailBody;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] AccountDTO accountLogin)
        {
            if (accountLogin.Username == null || accountLogin.Password == null)
            {
                return BadRequest("Please fill information");
            }

            if (CheckPasswordValidation(accountLogin.Password))
            {
                var acc = Authenticate(accountLogin.Username, accountLogin.Password);
                if (acc != null)
                {
                    var token = GenerateToken(acc);
                    if (token != null)
                    {
                        return Ok(new
                        {
                            token,
                            accountLogin.Username,
                            accountLogin.Password
                        });
                    }
                    return BadRequest("Token cannot create");
                }
                return NotFound("Account Not Found");
            }
            return BadRequest("Password is incorrect");
        }

        [HttpGet("CheckAuthenciation")]
        public IActionResult Check()
        {
            var s = GetCurrentAccount();
            if (s != null)
            {
                return Ok(s);
            }
            return NotFound();
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
            if (!CheckPasswordValidation(acc.Password))
            {
                return BadRequest("Password Ko Dat yeu cau");
            }
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
        public async Task<IActionResult> UpdateAccount(int id, AccountDTO acc)
        {
            if (id != acc.AccountId)
            {
                return BadRequest("Id Not Match");
            }
            acc.Password = _passwordHasher.Hash(acc.Password);
            var account = _mapper.Map<Account>(acc);

            var result = await _repository.UpdateAccount(account);
            if (!result)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPost("SendMailResetPassword")]
        public async Task<IActionResult> SendMailResetPassword(string mail)
        {
            var currentAccount = _context.Users.Where(x => x.Email == mail).FirstOrDefault();
            if (currentAccount != null)
            {
                try
                {
                    codeGenerate = GenerateCode.GenerateRandomCode();
                    await _emailSender
                        .SendEmailAsync(
                        mail,
                        _mailBody.SubjectTitleResetPassword(codeGenerate),
                        _mailBody.EmailBodyResetPassword(codeGenerate)
                        );
                    return Ok(new
                    {
                        message = "send to " + mail,
                        user = currentAccount
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest("Failed to send email. Please check the details and try again." +ex.Message);
                }
            }
            return BadRequest("User Not Found");

        }

        [HttpPost("CheckVerifyCode")]
        public ActionResult CheckVerifyCode(string code)
        {
            if (code == null || codeGenerate != code)
            {
                return BadRequest("Code Not Match");
            }
            return Ok("Matched");
        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(AccountDTO accountLogin)
        {
            if (accountLogin.Password == null)
            {
                return BadRequest("Please fill information");
            }

            if (CheckPasswordValidation(accountLogin.Password))
            {
                var acc = Authenticate(accountLogin.Username, accountLogin.Password);
                if (acc != null)
                {
                    return Ok("Allow to Change Password");
                }
            }
            return BadRequest("Password is invalid");
        }
        private User Authenticate(string username, string password)
        {
            var currentAccount = _context.Users
                .Include(x => x.Account)
                .ThenInclude(account => account.Role)
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
                         + " " + accountClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                         );
            }
            return null;
        }
        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                
                new Claim(ClaimTypes.NameIdentifier, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Account.Role.RoleName+" "+user.Id.ToString())
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
        private bool CheckPasswordValidation(string password)
        {
            // at least 1 Upper, 1 lowwer, 1 special character, 1 number
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";

            // Match the password against the pattern
            Match match = Regex.Match(password, pattern);

            // If the password matches the pattern, return true (valid)
            return match.Success;
        }
    }
}
