using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using Project_MLD.Utils.GenerateCode;
using Project_MLD.Utils.GmailSender;
using Project_MLD.Utils.PasswordHash;
using System.Security.Claims;


namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailSender _emailSender;
        private readonly IMailBody _mailBody;
        private readonly IGenerateCode _codeGenerate;


        public AccountController(IAccountRepository repository,
            IMapper mapper, IPasswordHasher passwordHasher,
            IEmailSender emailSender, IMailBody mailBody, IGenerateCode codeGenerate)
        {
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _emailSender = emailSender;
            _mailBody = mailBody;
            _codeGenerate = codeGenerate;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(string username, string password)
        {
            try
            {
                var accountLogin = new AccountDTO();
                accountLogin.Username = username;
                accountLogin.Password = password;

                //check username hoặc password nếu null
                if (accountLogin.Username == null || accountLogin.Password == null)
                {
                    return BadRequest("Please fill in all required fields.");
                }

                //kiểm tra xác thực của tài khoản
                var authenticatedAccount = _repository.AuthenticateAccountByUser(accountLogin.Username, accountLogin.Password);
                if (authenticatedAccount != null)
                {
                    var token = _repository.GenerateToken(authenticatedAccount);
                    if (token != null)
                    {
                        return Ok(token);
                    }
                    return BadRequest("Unable to generate token.");
                }
                return NotFound("User Not Found");
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("CheckAuthenciation")]
        public IActionResult CheckAuthenciation()
        {
            var s = GetCurrentAccount();
            if (s != null)
            {
                return Ok(s);
            }
            return NotFound("Account Not Found");
        }

        [HttpGet("GetAllAccounts")]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAllAccounts()
        {
            var acc = await _repository.GetAllAccounts();
            var mapAccount = _mapper.Map<List<AccountDTO>>(acc);
            return Ok(mapAccount);
        }

        [HttpGet("GetAccountById/{id}")]
        public async Task<ActionResult<Account>> GetAccountById(int id)
        {
            var exAcc = await _repository.GetAccountById(id);
            if (exAcc == null)
            {
                return NotFound("Account not exist");
            }
            return Ok(exAcc);
        }

        [HttpPost("AddAccount")]
        public async Task<ActionResult<AccountDTO>> AddAccount(AccountDTO acc)
        {
            //Check exist
            var existAccount = _repository.GetAccountByUsername(acc.Username);
            if (existAccount != null)
            {
                return BadRequest("Account Exist");
            }

            acc.Active = true;
            acc.CreatedBy = 1;
            acc.CreatedDate = DateOnly.FromDateTime(DateTime.Now);
            acc.LoginLast = DateTime.Now;
            acc.LoginAttempt = 0;
            acc.Password = _passwordHasher.Hash(acc.Password);

            var account = _mapper.Map<Account>(acc);

            var accountCreated = await _repository.AddAccount(account);

            return Ok(accountCreated);
        }

        [HttpPut("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount(AccountDTO acc)
        {
            if (acc.Password != null)
            {
                acc.Password = _passwordHasher.Hash(acc.Password);
            }

            var account = _mapper.Map<Account>(acc);

            var result = await _repository.UpdateAccount(account);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("SendMailResetPassword")]
        public async Task<IActionResult> SendMailResetPassword(string mail)
        {
            var currentAccount = await _repository.GetUserByEmail(mail);

            if (currentAccount != null)
            {
                try
                {
                    var account = await _repository.GetAccountById(currentAccount.AccountId);

                    if (account != null)
                    {
                        var codeGenerate = _codeGenerate.GenerateRandomCode();

                        var hashedPassword = _passwordHasher.Hash(codeGenerate);
                        account.Password = hashedPassword;

                        // Update account password
                        await _repository.UpdateAccount(account);
                        //_context.Accounts.Update(account);
                        //await _context.SaveChangesAsync();
                        // Send email
                        await _emailSender.SendEmailAsync(
                            mail,
                            _mailBody.SubjectTitleResetPassword(codeGenerate),
                            _mailBody.EmailBodyResetPassword(account.Username, codeGenerate)
                        );
                        return Ok(new { message = "Reset password email sent to " + mail });
                    }
                    else
                    {
                        return BadRequest("Account not found for the user.");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest("Failed to send email. Please check the details and try again. " + ex.Message);
                }
            }
            else
            {
                return BadRequest("User not found.");
            }
        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(string username, string currentPassword, string newPassword)
        {
            try
            {
                var account = _repository.GetAccountByUsername(username);

                if (account == null)
                {
                    return BadRequest("User not found.");
                }

                if (!_passwordHasher.VerifyPassword(account.Password, currentPassword))
                {
                    return BadRequest("Incorrect current password.");
                }

                if (!_repository.CheckPasswordValidation(newPassword))
                {
                    return BadRequest("At least 8 characters including 1 special case, 1 lowwer case, 1 uppercase and 1 number");
                }

                var hashedNewPassword = _passwordHasher.Hash(newPassword);
                if (account.LoginAttempt == 0 || account.LoginAttempt == null || account.LoginAttempt < 0)
                {
                    account.LoginAttempt = 1;
                }
                else
                {
                    account.LoginAttempt++;
                }
                account.Password = hashedNewPassword;
                await _repository.UpdateAccount(account);
                //_context.Accounts.Update(account);
                //_context.SaveChanges();

                return Ok("Password updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to update password. Please try again. " + ex.Message);
            }
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAccount(int id)
        //{
        //    var result = await _repository.DeleteAccount(id);
        //    if (!result)
        //    {
        //        return NotFound();
        //    }
        //    return NoContent();
        //}

        private string GetCurrentAccount()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var accountClaims = identity.Claims;
                return (accountClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value
                       + " " + accountClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value
                        + " " + accountClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value
                         + " " + accountClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                         );
            }
            return null;
        }
    }
}
