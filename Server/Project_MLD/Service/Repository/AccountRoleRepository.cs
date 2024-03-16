using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class AccountRoleRepository : IAccountRoleRepository
    {
        private readonly MldDatabaseContext _context;

        public AccountRoleRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<AccountRole> AddAccountRole(AccountRole ar)
        {
            _context.AccountRoles.Add(ar);
            await _context.SaveChangesAsync();
            return ar;
        }
        public async Task<IEnumerable<AccountRole>> GetAllAccountRoles()
        {
            return await _context.AccountRoles.ToListAsync();
        }
        public async Task<AccountRole> GetAccountRoleByAccountId(int id)
        {
            return await _context.AccountRoles.FindAsync(id);
        }
    }
}
