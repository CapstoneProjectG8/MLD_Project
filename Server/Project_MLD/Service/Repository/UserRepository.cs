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

        public async Task<IEnumerable<object>> GetTotalTeacherLevelOfTrainning()
        {
            var levelCounts = await _context.LevelOfTrainnings
                .Include(x => x.Users) 
                .Select(x => new
                {
                    LevelName = x.Name,
                    UserCount = x.Users.Count()
                })
                .ToListAsync();

            return levelCounts;
        }

        public async Task<IEnumerable<object>> GetTotalTeacherProfessionalStandard()
        {
            var professionalCount = await _context.ProfessionalStandards
                .Include(x => x.Users)
                .Select(x => new
                {
                    LevelName = x.Name,
                    UserCount = x.Users.Count()
                })
                .ToListAsync();

            return professionalCount;
        }

        public async Task<IEnumerable<object>> GetTotalUserBySpecializedDepartmentId(int id)
        {
            var specializedDepartment = await _context.SpecializedDepartments
                .Include(x => x.Users)
                .Where(x => x.Id == id)
                .Select(x => new
                {
                    SpecializedDepartmentId = x.Id,
                    SpecializedDepartmentName = x.Name,
                    UserCount = x.Users.Count()
                })
                .ToListAsync();

            return specializedDepartment;
        }

    }
}
