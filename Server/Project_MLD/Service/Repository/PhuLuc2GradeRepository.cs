using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class PhuLuc2GradeRepository : IPhuLuc2GradeRepository
    {
        private readonly MldDatabaseContext _context;

        public PhuLuc2GradeRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<PhuLuc2Grade> AddPhuLuc2Grade(PhuLuc2Grade pl2)
        {
            _context.PhuLuc2Grades.Add(pl2);
            await _context.SaveChangesAsync();
            return pl2;
        }

        public async Task<bool> DeletePhuLuc2Grade(int id)
        {
            var existPhuLuc2Grade = await GetPhuLuc2GradeById(id);
            if (existPhuLuc2Grade == null)
            {
                return false;
            }
            _context.PhuLuc2Grades.Remove(existPhuLuc2Grade);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PhuLuc2Grade>> GetAllPhuLuc2Grades()
        {
            return await _context.PhuLuc2Grades.ToListAsync();
        }

        public async Task<PhuLuc2Grade> GetPhuLuc2GradeById(int id)
        {
            return await _context.PhuLuc2Grades
                .Include(x => x.Pl2)
                .FirstOrDefaultAsync(x => x.Pl2Id == id);
        }

        public async Task<bool> UpdatePhuLuc2Grade(PhuLuc2Grade pl2)
        {
            var existPhuLuc2Grade = await GetPhuLuc2GradeById(pl2.Pl2.Id);
            if (existPhuLuc2Grade == null)
            {
                return false;
            }

            _context.Entry(existPhuLuc2Grade).CurrentValues.SetValues(pl2);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
