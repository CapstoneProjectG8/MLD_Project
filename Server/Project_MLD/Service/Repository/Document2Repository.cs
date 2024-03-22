using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document2Repository : IDocument2Repository
    {
        private readonly MldDatabaseContext _context;

        public Document2Repository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Document2> AddDocument2(Document2 pl2)
        {
            _context.Document2s.Add(pl2);
            await _context.SaveChangesAsync();
            return pl2;
        }

        public async Task<bool> DeleteDocument2(int id)
        {
            var existDocument2 = await GetDocument2ById(id);
            if (existDocument2 == null)
            {
                return false;
            }
            _context.Document2s.Remove(existDocument2);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Document2>> GetAllDocument2s()
        {
            return await _context.Document2s.ToListAsync();
        }

        public async Task<Document2> GetDocument2ById(int id)
        {
            return await _context.Document2s.FindAsync(id);
        }

        public async Task<bool> UpdateDocument2(Document2 pl2)
        {
            var existDocument2 = await GetDocument2ById(pl2.Id);
            if (existDocument2 == null)
            {
                return false;
            }

            _context.Entry(existDocument2).CurrentValues.SetValues(pl2);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
