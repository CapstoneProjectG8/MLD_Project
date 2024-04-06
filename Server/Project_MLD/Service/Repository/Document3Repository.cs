using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document3Repository : IDocument3Repository
    {
        private readonly MldDatabaseContext _context;

        public Document3Repository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Document3> AddDocument3(Document3 pl3)
        {
            _context.Document3s.Add(pl3);
            await _context.SaveChangesAsync();
            return pl3;
        }

        public async Task<bool> DeleteDocument3(int id)
        {
            var existDocument3 = await GetDocument3ById(id);
            if (existDocument3 == null)
            {
                return false;
            }
            _context.Document3s.Remove(existDocument3);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Document3>> GetAllDocument3s()
        {
            return await _context.Document3s
                .Include(x => x.User)
                .Include(x => x.Document1)
                .Where(x => x.Status == true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Document3>> GetDocument3ByApproval()
        {
            return await _context.Document3s
                .Include(x => x.User)
                .Include(x => x.Document1)
                .Where(x => x.Status == true && x.IsApprove == true).ToListAsync();
        }

        public async Task<Document3> GetDocument3ById(int id)
        {
            return await _context.Document3s
                .Include(x => x.Document1)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Document3>> GetDocument3sByCondition(string condition)
        {
            return await _context.Document3s
                .Include(x => x.User)
                .Where(x => x.Name == condition ||
                x.User.FullName.Contains(condition) ||
                x.User.FirstName.Contains(condition) ||
                x.User.LastName.Contains(condition))
                .ToListAsync();
        }

        public async Task<bool> UpdateDocument3(Document3 pl3)
        {
            var existDocument3s = await GetDocument3ById(pl3.Id);
            if (existDocument3s == null)
            {
                return false;
            }

            var properties = typeof(Document3).GetProperties();
            foreach (var property in properties)
            {
                var updatedValue = property.GetValue(pl3);
                if (updatedValue != null)
                {
                    property.SetValue(existDocument3s, updatedValue);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
