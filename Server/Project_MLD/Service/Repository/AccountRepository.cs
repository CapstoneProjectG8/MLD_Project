using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using Project_MLD.Utils.PasswordHash;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace Project_MLD.Service.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MldDatabase2Context _context;
        private readonly IPasswordHasher _passwordHasher;
        private IConfiguration _config;

        public AccountRepository(MldDatabase2Context context, IPasswordHasher passwordHasher, IConfiguration config)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _config = config;
        }

        public async Task<Account> AddAccount(Account acc)
        {
            _context.Accounts.Add(acc);
            await _context.SaveChangesAsync();
            return acc;
        }

        public async Task<bool> DeleteAccount(int id)
        {
            var existAccount = await GetAccountById(id);
            if (existAccount == null)
            {
                return false;
            }
            _context.Accounts.Remove(existAccount);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetAccountById(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<Account> UpdateAccount(Account acc)
        {
            var existAccount = await GetAccountById(acc.AccountId);
            if (existAccount == null)
            {
                return null;
            }
            var properties = typeof(Account).GetProperties();
            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(acc);
                if (updatedValue != null)
                {
                    property.SetValue(existAccount, updatedValue);
                }
            }

            await _context.SaveChangesAsync();
            return existAccount;
        }

        public Account GetAccountByUsername(string username)
        {
            var existAccount = _context.Accounts.FirstOrDefault(x => x.Username == username);
            if (existAccount == null)
            {
                return null;
            }
            return existAccount;
        }

        public User AuthenticateAccountByUser(string username, string password)
        {
            try
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
                        if (currentAccount.Account.LoginAttempt == 0 || currentAccount.Account.LoginAttempt == null)
                        {
                            throw new Exception("Please change your password on first login.");
                        }
                        else
                        {
                            UpdateAccountLoginInfo(currentAccount.Account);
                            return currentAccount;
                        }
                    }
                    else
                    {
                        throw new Exception("Incorrect password.");
                    }
                }
                else
                {
                    throw new Exception("Account not found.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateAccountLoginInfo(Account account)
        {
            account.LoginAttempt++;
            account.LoginLast = DateTime.Now;

            _context.Accounts.Update(account);
            _context.SaveChanges();
        }

        public bool CheckPasswordValidation(string password)
        {
            // at least 1 Upper, 1 lowwer, 1 special character, 1 number
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";

            // Match the password against the pattern
            Match match = Regex.Match(password, pattern);

            // If the password matches the pattern, return true (valid)
            return match.Success;
        }

        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.FirstName + " " + user.LastName),
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

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }


    }
}
