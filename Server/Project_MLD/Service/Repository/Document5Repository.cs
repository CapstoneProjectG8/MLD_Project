using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document5Repository : IDocument5Repository
    {
        private readonly MldDatabase2Context _context;

        public Document5Repository(MldDatabase2Context context)
        {
            _context = context;
        }

        public async Task<Document5> AddDocument5(Document5 pl5)
        {
            _context.Document5s.Add(pl5);
            await _context.SaveChangesAsync();
            return pl5;
        }

        public async Task<bool> DeleteDocument5(int id)
        {
            var existDocument5 = await GetDocument5ById(id);
            if (existDocument5 == null)
            {
                return false;
            }
            _context.Document5s.Remove(existDocument5);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Document5>> GetAllDocument5s()
        {
            return await _context.Document5s.ToListAsync();
        }

        public async Task<Document5> GetDocument5ById(int id)
        {
            return await _context.Document5s.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Document5>> GetDocument5sByCondition(string condition)
        {
            return await _context.Document5s
                .Include(x => x.User)
                .Where(x => x.Name.Contains(condition) ||
                x.User.LastName.Contains(condition) ||
                x.User.FirstName.Contains(condition))
                .ToListAsync();
        }

        public async Task<IEnumerable<Document5>> GetDocument5sbyUserId(int userId)
        {
            return await _context.Document5s.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Document5>> GetDoucment5ByDoc4(int id)
        {
            return await _context.Document5s
                .Include(x => x.User)
                .Where(x => x.Document4Id == id)
                .ToListAsync();
        }

        public async Task<bool> UpdateDocument5(Document5 pl5)
        {
            var existDocument5s = await GetDocument5ById(pl5.Id);
            if (existDocument5s == null)
            {
                return false;
            }

            _context.Entry(existDocument5s).CurrentValues.SetValues(pl5);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
