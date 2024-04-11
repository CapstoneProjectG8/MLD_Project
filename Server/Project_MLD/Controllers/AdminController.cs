using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.DTO;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using Project_MLD.Utils.PasswordHash;
using System.Text.RegularExpressions;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public AdminController(IAdminRepository repository, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAllAccount()
        {
            var acc = await _repository.GetAllAccounts();
            var mapper = _mapper.Map<AccountDTO>(acc);
            return Ok(mapper);
        }
        [HttpGet("GetAllNotification")]
        public async Task<ActionResult<IEnumerable<Notification>>> GetAllNotification()
        {
            var noti = await _repository.GetAllNotification();
            return Ok(noti);
        }
        [HttpGet("GetAllFeedback")]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetAllFeedback()
        {
            var feedbacks = await _repository.GetAllFeedback();
            return Ok(feedbacks);
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

        [HttpGet("GetAccountByUsername")]
        public async Task<ActionResult<Account>> GetAccountByUsername(string username)
        {
            var exAcc = await _repository.GetAccountByUsername(username);
            if (exAcc == null)
            {
                return NotFound();
            }

            return Ok(exAcc);
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
