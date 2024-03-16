using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class PhuLuc1Repository : IPhuLuc1Repository
    {
        private readonly MldDatabaseContext _context;

        public PhuLuc1Repository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<PhuLuc1> AddPhuLuc1(PhuLuc1 pl1)
        {
            _context.PhuLuc1s.Add(pl1);
            await _context.SaveChangesAsync();
            return pl1;
        }

        public async Task<bool> DeletePhuLuc1(int id)
        {
            var pl1 = await GetPhuLuc1ById(id);
            if (pl1 == null)
            {
                return false;
            }
            _context.PhuLuc1s.Remove(pl1);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PhuLuc1>> GetAllPhuLuc1s()
        {
            return await _context.PhuLuc1s.ToListAsync();
        }

        public async Task<PhuLuc1> GetPhuLuc1ById(int id)
        {
            return await _context.PhuLuc1s.FindAsync(id);
        }

        public async Task<bool> UpdatePhuLuc1(PhuLuc1 pl1)
        {
            var existPhuLuc1 = await GetPhuLuc1ById(pl1.Id);
            if (existPhuLuc1 == null)
            {
                return false;
            }

            _context.Entry(existPhuLuc1).CurrentValues.SetValues(pl1);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
