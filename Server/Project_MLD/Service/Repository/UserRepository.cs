using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;
using System.Collections.Immutable;

namespace Project_MLD.Service.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MldDatabase2Context _context;

        public UserRepository(MldDatabase2Context context)
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

        public async Task<bool> UpdateUser(User user)
        {
            var existUser = await GetUserById(user.Id);
            if (existUser == null)
            {
                return false;
            }
            var properties = typeof(User).GetProperties();
            foreach (var property in properties)
            {
                var updateValue = property.GetValue(user);
                if (updateValue != null)
                {
                    property.SetValue(existUser, updateValue);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<object>> GetTotalUserLevelOfTrainning(int departmentId)
        {
            var levelCounts = await _context.LevelOfTrainnings
                .Include(x => x.Users)
                .Where(x => x.Users.Any(u => u.DepartmentId == departmentId))
                .Select(x => new
                {
                    LevelName = x.Name,
                    UserCount = x.Users.Count(x => x.DepartmentId == departmentId)
                })
                .ToListAsync();

            return levelCounts;
        }

        public async Task<IEnumerable<object>> GetTotalUserProfessionalStandard(int departmentId)
        {
            var result = await _context.ProfessionalStandards
                .Where(ps => ps.Users.Any(u => u.DepartmentId == departmentId))
                .Select(ps => new
                {
                    ProfessionalStandard = ps.Name,
                    UserCount = ps.Users.Count(u => u.DepartmentId == departmentId)
                })
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<User>> GetPrinciples()
        {
            return await _context.Users
               .Include(x => x.Account)
                   .ThenInclude(x => x.Role)
               .Where(x => x.Account.Role.RoleId == 4)
               .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersByDepartmentId(int id)
        {
            return await _context.Users
                .Include(x => x.Account)
                   .ThenInclude(x => x.Role)
                .Where(x => x.DepartmentId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<object>> GetTotalUserBySpecializedDepartmentId(int id)
        {
            var totalUsers = await _context.Users
                .Where(x => x.DepartmentId == id)
                .GroupBy(x => x.DepartmentId)
                .Select(g => new
                {
                    DepartmentId = g.Key,
                    UserCount = g.Count()
                })
                .ToListAsync();

            return totalUsers;
        }

        public async Task<User> GetUserIsRole(int userId, int roleId)
        {
            var user = await _context.Users
              .Include(x => x.Account)
                  .ThenInclude(x => x.Role)
              .FirstOrDefaultAsync(x => x.Id == userId && x.Account.RoleId == roleId);

            return user;
        }
    }
}
