using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class PhuLuc3Repository : IPhuLuc3Repository
    {
        private readonly MldDatabaseContext _context;

        public PhuLuc3Repository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<PhuLuc3> AddPhuLuc3(PhuLuc3 pl3)
        {
            _context.PhuLuc3s.Add(pl3);
            await _context.SaveChangesAsync();
            return pl3;
        }

        public async Task<bool> DeletePhuLuc3(int id)
        {
            var existPhuLuc3 = await GetPhuLuc3ById(id);
            if (existPhuLuc3 == null)
            {
                return false;
            }
            _context.PhuLuc3s.Remove(existPhuLuc3);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PhuLuc3>> GetAllPhuLuc3s()
        {
            return await _context.PhuLuc3s.ToListAsync();
        }

        public async Task<PhuLuc3> GetPhuLuc3ById(int id)
        {
            return await _context.PhuLuc3s.FindAsync(id);
        }

        public async Task<bool> UpdatePhuLuc3(PhuLuc3 pl3)
        {
            var existPhuLuc3 = await GetPhuLuc3ById(pl3.Id);
            if (existPhuLuc3 == null)
            {
                return false;
            }

            _context.Entry(existPhuLuc3).CurrentValues.SetValues(pl3);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
