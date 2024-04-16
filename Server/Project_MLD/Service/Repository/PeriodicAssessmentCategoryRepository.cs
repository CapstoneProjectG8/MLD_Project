using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class PeriodicAssessmentCategoryRepository : IPeriodicAssessmentCategoryRepository
    {
        private readonly MldDatabaseContext _context;

        public PeriodicAssessmentCategoryRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FormCategory>> GetAllFormCategory()
        {
            return await _context.FormCategories.ToListAsync();
        }

        public async Task<IEnumerable<TestingCategory>> GetAllTestingCategory()
        {
            return await _context.TestingCategories.ToListAsync();
        }

        public async Task<FormCategory> GetFormCategoryById(int id)
        {
            return await _context.FormCategories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TestingCategory> GetTestingCategoryById(int id)
        {
            return await _context.TestingCategories.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
