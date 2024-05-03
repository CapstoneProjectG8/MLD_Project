using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly MldDatabase2Context _context;

        public ClassRepository(MldDatabase2Context context)
        {
            _context = context;
        }

        public async Task<Class> AddClass(Class Class)
        {
            _context.Classes.Add(Class);
            await _context.SaveChangesAsync();
            return Class;
        }

        public async Task<bool> DeleteClass(int id)
        {
            var existClass = await GetClassById(id);
            if (existClass == null)
            {
                return false;
            }
            _context.Classes.Remove(existClass);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Class>> GetAllClasss()
        {
            return await _context.Classes.Include(x => x.Grade).ToListAsync();
        }

        public async Task<Class> GetClassById(int id)
        {
            return await _context.Classes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Class>> GetClassesByGradeId(int gradeId)
        {
            return await _context.Classes.Where(x => x.GradeId == gradeId).ToListAsync();
        }

        public async Task<bool> UpdateClass(Class cl)
        {
            var existClass = await GetClassById(cl.Id);
            if (existClass == null)
            {
                return false;
            }

            _context.Entry(existClass).CurrentValues.SetValues(cl);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
