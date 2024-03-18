using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MldDatabaseContext _context;

        public UserRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User User)
        {
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            return User;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var User = await GetUserById(id);
            if (User == null)
            {
                return false;
            }
            _context.Users.Remove(User);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> UpdateUser(User User)
        {
            var existUser = await GetUserById(User.Id);
            if (existUser == null)
            {
                return false;
            }

            _context.Entry(existUser).CurrentValues.SetValues(User);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
