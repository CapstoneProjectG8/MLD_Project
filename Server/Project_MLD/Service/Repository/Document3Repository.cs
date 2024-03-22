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
            return await _context.Document3s.ToListAsync();
        }

        public async Task<Document3> GetDocument3ById(int id)
        {
            return await _context.Document3s.FindAsync(id);
        }

        public async Task<bool> UpdateDocument3(Document3 pl3)
        {
            var existDocument3s = await GetDocument3ById(pl3.Id);
            if (existDocument3s == null)
            {
                return false;
            }

            _context.Entry(existDocument3s).CurrentValues.SetValues(pl3);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
