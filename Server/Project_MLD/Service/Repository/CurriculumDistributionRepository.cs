using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class CurriculumDistributionRepository : ICurriculumDistributionRepository
    {
        private readonly MldDatabaseContext _context;

        public CurriculumDistributionRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<CurriculumDistribution> AddCurriculumDistribution(CurriculumDistribution cd)
        {
            _context.CurriculumDistributions.Add(cd);
            await _context.SaveChangesAsync();
            return cd;
        }

        public async Task<bool> DeleteCurriculumDistribution(int id)
        {
            var existCurriculumDistribution = await GetCurriculumDistributionById(id);
            if (existCurriculumDistribution == null)
            {
                return false;
            }
            _context.CurriculumDistributions.Remove(existCurriculumDistribution);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CurriculumDistribution>> GetAllCurriculumDistributions()
        {
            return await _context.CurriculumDistributions.ToListAsync();
        }

        public async Task<CurriculumDistribution> GetCurriculumDistributionById(int id)
        {
            return await _context.CurriculumDistributions.FindAsync(id);
        }

        public async Task<bool> UpdateCurriculumDistribution(CurriculumDistribution cd)
        {
            var existCurriculumDistribution = await GetCurriculumDistributionById(cd.Id);
            if (existCurriculumDistribution == null)
            {
                return false;
            }

            _context.Entry(existCurriculumDistribution).CurrentValues.SetValues(cd);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
