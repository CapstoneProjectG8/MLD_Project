using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class PhuLuc2Repository : IPhuLuc2Repository
    {
        private readonly MldDatabaseContext _context;

        public PhuLuc2Repository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<PhuLuc2> AddPhuLuc2(PhuLuc2 pl2)
        {
            _context.PhuLuc2s.Add(pl2);
            await _context.SaveChangesAsync();
            return pl2;
        }

        public async Task<bool> DeletePhuLuc2(int id)
        {
            var existPhuLuc2 = await GetPhuLuc2ById(id);
            if (existPhuLuc2 == null)
            {
                return false;
            }
            _context.PhuLuc2s.Remove(existPhuLuc2);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PhuLuc2>> GetAllPhuLuc2s()
        {
            return await _context.PhuLuc2s.ToListAsync();
        }

        public async Task<PhuLuc2> GetPhuLuc2ById(int id)
        {
            return await _context.PhuLuc2s.FindAsync(id);
        }

        public async Task<bool> UpdatePhuLuc2(PhuLuc2 pl2)
        {
            var existPhuLuc2 = await GetPhuLuc2ById(pl2.Id);
            if (existPhuLuc2 == null)
            {
                return false;
            }

            _context.Entry(existPhuLuc2).CurrentValues.SetValues(pl2);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
