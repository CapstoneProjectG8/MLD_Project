using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document1PeriodicAssessmentCategoryRepository : IDocument1PeriodicAssessmentCategoryRepository
    {
        private readonly MldDatabase2Context _context;

        public Document1PeriodicAssessmentCategoryRepository(MldDatabase2Context context)
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
