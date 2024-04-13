using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document3CuriculumDistributionRepository : IDocument3CurriculumDistributionRepository
    {
        private readonly MldDatabaseContext _context;

        public Document3CuriculumDistributionRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public Task DeleteDocument3CurriculumDistribution(List<Document3CurriculumDistribution> dc)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Document3CurriculumDistribution>> GetCurriculumDistributionByDocument3Id(int id)
        {
            var cd = await _context.Document3CurriculumDistributions
                 .Where(x => x.Document3Id == id)
                 .ToListAsync();
            return cd;
        }

        public async Task UpdateDocument3CurriculumDistribution(List<Document3CurriculumDistribution> list)
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

                    var equipment = await _context.TeachingEquipments
                        .FindAsync(item.EquipmentId);
                    if (equipment == null)
                    {
                        equipment = new TeachingEquipment
                        {
                            Name = item.Equipment.Name
                        };
                        _context.TeachingEquipments.Add(equipment);
                    }

                    var existingItem = await _context.Document3CurriculumDistributions
                        .FindAsync(item.Document3Id, item.CurriculumId, item.EquipmentId);
                    if (existingItem == null)
                    {
                        var newItem = new Document3CurriculumDistribution
                        {
                            Document3Id = item.Document3Id,
                            CurriculumId = item.CurriculumId,
                            EquipmentId = item.EquipmentId,
                            Slot = item.Slot,
                            Time = item.Time,
                            SubjectRoomName = item.SubjectRoomName
                        };
                        _context.Document3CurriculumDistributions.Add(newItem);
                    }
                    else
                    {
                        existingItem.Slot = item.Slot;
                        existingItem.Time = item.Time;
                        existingItem.SubjectRoomName = item.SubjectRoomName;
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating Curriculum Distributions.", ex);
            }
        }

    }
}
