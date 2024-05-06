using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document1CuriculumDistributionRepository : IDocument1CuriculumDistributionRepository
    {
        private readonly MldDatabase2Context _context;

        public Document1CuriculumDistributionRepository(MldDatabase2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Document1CurriculumDistribution>> GetCurriculumDistributionByDocument1Id(int id)
        {
            var cd = await _context.Document1CurriculumDistributions
                .Include(x => x.Curriculum)
                .Include(x => x.Document1)
                .Where(x => x.Document1Id == id)
                .ToListAsync();
            return cd;
        }

        public async Task AddDocument1CurriculumDistribution(List<Document1CurriculumDistribution> list)
        {
            try
            {
                foreach (var item in list)
                {
                    _context.Document1CurriculumDistributions.Add(item);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteDocument1CurriculumDistribution(List<Document1CurriculumDistribution> list)
        {
            if (list == null || !list.Any())
            {
                throw new Exception("An error occurred while delete Curriculum Distributions.");
            }

            foreach (var item in list)
            {
                var existingItem = await _context.Document1CurriculumDistributions
                  .FindAsync(item.Document1Id, item.CurriculumId);

                if (existingItem != null)
                {
                    _context.Document1CurriculumDistributions.Remove(existingItem);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteDocument1CurriculumDistributionByDoc1ID(int id)
        {
            var existingDoc1CD = await _context.Document1CurriculumDistributions
                .Where(x => x.Document1Id == id).ToListAsync();

            if (existingDoc1CD != null)
            {
                _context.RemoveRange(existingDoc1CD);
            }
            await _context.SaveChangesAsync();
        }
    }
}
