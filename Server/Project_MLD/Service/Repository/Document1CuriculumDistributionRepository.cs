using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document1CuriculumDistributionRepository : IDocument1CuriculumDistributionRepository
    {
        private readonly MldDatabaseContext _context;

        public Document1CuriculumDistributionRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Document1CurriculumDistribution>> GetCurriculumDistributionByDocument1Id(int id)
        {
            var cd = await _context.Document1CurriculumDistributions
                .Where(x => x.Document1Id == id)
                .ToListAsync();
            return cd;
        }

        public async Task UpdateDocument1CurriculumDistribution(List<Document1CurriculumDistribution> list)
        {
            try
            {
                foreach (var item in list)
                {
                    var curriculum = await _context.CurriculumDistributions
                        .FindAsync(item.CurriculumId);
                    if (curriculum == null)
                    {
                        curriculum = new CurriculumDistribution
                        {
                            Name = item.Curriculum.Name
                        };
                        _context.CurriculumDistributions.Add(curriculum);
                    }
                    var existingItem = await _context.Document1CurriculumDistributions
                        .FindAsync(item.Document1Id, item.CurriculumId);
                    if (existingItem == null)
                    {
                        var newItem = new Document1CurriculumDistribution
                        {
                            Document1Id = item.Document1Id,
                            CurriculumId = item.CurriculumId,
                            Slot = item.Slot,
                            Description = item.Description
                        };
                        _context.Document1CurriculumDistributions.Add(newItem);
                    }
                    else
                    {
                        existingItem.Slot = item.Slot;
                        existingItem.Description = item.Description;
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating CurriculumDistributions.", ex);
            }
        }

        public Task DeleteDocument1CurriculumDistribution(List<Document1CurriculumDistribution> list)
        {
            throw new NotImplementedException();
        }

    }
}
