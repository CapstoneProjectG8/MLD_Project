using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document2GradeRepository : IDocument2GradeRepository
    {
        private readonly MldDatabaseContext _context;

        public Document2GradeRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Document2Grade> AddDocument2Grade(Document2Grade pl2)
        {
            _context.Document2Grades.Add(pl2);
            await _context.SaveChangesAsync();
            return pl2;
        }

        public async Task<bool> DeleteDocument2Grade(int id)
        {
            var existDocument2Grade = await GetDocument2GradeById(id);
            if (existDocument2Grade == null)
            {
                return false;
            }
            _context.Document2Grades.Remove(existDocument2Grade);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Document2Grade>> GetAllDocuemnt2Grades()
        {
            return await _context.Document2Grades.ToListAsync();
        }

        public async Task<Document2Grade> GetDocument2GradeById(int id)
        {
            return await _context.Document2Grades
                .Include(x => x.Document2)
                .FirstOrDefaultAsync(x => x.Document2Id == id);
        }

        public async Task<bool> UpdateDocument2Grade(Document2Grade pl2)
        {
            var existDocument2Grade = await GetDocument2GradeById(pl2.Document2.Id);
            if (existDocument2Grade == null)
            {
                return false;
            }

            _context.Entry(existDocument2Grade).CurrentValues.SetValues(pl2);
            await _context.SaveChangesAsync();
            return true;
        }
    }

    
}
