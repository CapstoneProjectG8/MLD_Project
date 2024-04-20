using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document4Repository : IDocument4Repository
    {
        private readonly MldDatabaseContext _context;

        public Document4Repository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Document4> AddDocument4(Document4 pl4)
        {
            _context.Document4s.Add(pl4);
            await _context.SaveChangesAsync();
            return pl4;
        }

        public async Task<bool> DeleteDocument4(int id)
        {
            var existDocument4 = await GetDocument4ById(id);
            if (existDocument4 == null)
            {
                return false;
            }
            _context.Document4s.Remove(existDocument4);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Document4>> GetAllDocument4s()
        {
            return await _context.Document4s
                .Include(x => x.TeachingPlanner)
                .Where(x => x.Status == true)
                .ToListAsync();
        }

        public async Task<Document4> GetDocument4ById(int id)
        {
            return await _context.Document4s.FindAsync(id);
        }

        public async Task<IEnumerable<Document4>> GetDocument4ByUserSpecialiedDepartment(int id)
        {
            return await _context.Document4s
                .Include(x => x.TeachingPlanner)
                .ThenInclude(x => x.User)
                .Where(x => x.Status == true && x.TeachingPlanner.User.SpecializedDepartmentId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Document4>> GetDocument4sByCondition(string condition)
        {
            return await _context.Document4s
                .Include(x => x.TeachingPlanner)
                .ThenInclude(x => x.User)
                .Where(x => x.Name == condition ||
                x.Name.Contains(condition) ||
                x.TeachingPlanner.User.FullName.Contains(condition) ||
                x.TeachingPlanner.User.FirstName.Contains(condition) ||
                x.TeachingPlanner.User.LastName.Contains(condition))
                .ToListAsync();
        }

        public async Task<bool> UpdateDocument4(Document4 pl4)
        {
            var existDocument4s = await GetDocument4ById(pl4.Id);
            if (existDocument4s == null)
            {
                return false;
            }

            _context.Entry(existDocument4s).CurrentValues.SetValues(pl4);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
