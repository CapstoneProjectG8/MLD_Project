using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MldDatabase2Context _context;

        public RoleRepository(MldDatabase2Context context)
        {
            _context = context;
        }

        public async Task<Role> AddRole(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteRole(int id)
        {
            var role = await GetRoleById(id);
            if (role == null)
            {
                return false;
            }
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<bool> UpdateRole(Role role)
        {
            var existRole = await GetRoleById(role.RoleId);
            if (existRole == null)
            {
                return false;
            }

            _context.Entry(existRole).CurrentValues.SetValues(role);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
