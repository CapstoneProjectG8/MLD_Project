using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document1Repository : IDocument1Repository
    {
        private readonly MldDatabaseContext _context;

        public Document1Repository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Document1> AddDocument1(Document1 document1)
        {
            _context.Document1s.Add(document1);
            await _context.SaveChangesAsync();
            return document1;
        }

        public async Task<bool> DeleteDocument1(int id)
        {
            var document1 = await GetDocument1ById(id);
            if (document1 == null)
            {
                return false;
            }
            _context.Document1s.Remove(document1);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Document1>> GetAllDocument1s()
        {
            return await _context.Document1s
                .Include(x => x.Grade)
                .Include(x => x.Subject)
                .Include(x => x.User)
                .Where(x => x.Status == true).ToListAsync();
        }

        public async Task<IEnumerable<Document1>> GetDocument1ByApproval()
        {
            return await _context.Document1s
                .Include(x => x.Grade)
                .Include(x => x.Subject)
                .Include(x => x.User)
                .Where(x => x.Status == true && x.IsApprove == true).ToListAsync();
        }

        public async Task<IEnumerable<Document1>> GetDocument1ByCondition(string condition)
        {
            return await _context.Document1s
                .Include(x => x.User)
                .Include(x => x.Grade)
                .Include(x => x.Subject)
                .Where(x => x.Name == condition ||
                x.User.FullName.Contains(condition) ||
                x.User.FirstName.Contains(condition) ||
                x.User.LastName.Contains(condition))
                .ToListAsync();
        }

        public async Task<Document1> GetDocument1ById(int id)
        {
            var doc = await _context.Document1s
                .Include(x => x.User)
                .Include(x => x.Grade)
                .Include(x => x.Subject)
                .FirstOrDefaultAsync(x => x.Id == id);
            return doc;
        }

        public async Task<bool> UpdateDocument1(Document1 document1)
        {
            var existDocument1 = await _context.Document1s.FindAsync(document1.Id);
            if (existDocument1 == null)
            {
                return false;
            }

            var entityType = typeof(Document1);
            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                var newValue = property.GetValue(document1);
                if (newValue != null)
                {
                    property.SetValue(existDocument1, newValue);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
