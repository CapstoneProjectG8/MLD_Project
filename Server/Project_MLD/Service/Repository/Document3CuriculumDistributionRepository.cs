using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;
using System.Collections.Generic;

namespace Project_MLD.Service.Repository
{
    public class Document3CuriculumDistributionRepository : IDocument3CurriculumDistributionRepository
    {
        private readonly MldDatabase2Context _context;

        public Document3CuriculumDistributionRepository(MldDatabase2Context context)
        {
            _context = context;
        }

        public async Task<Document3CurriculumDistribution> AddDoc3curriculumDistribution(Document3CurriculumDistribution cd)
        {
            await _context.Document3CurriculumDistributions.AddAsync(cd);
            await _context.SaveChangesAsync();
            return cd;
        }

        public async Task DeleteDocument3CurriculumDistribution(List<Document3CurriculumDistribution> list)
        {
            if (list == null || !list.Any())
            {
                return; // Nothing to delete
            }

            foreach (var item in list)
            {
                var existingItem = await _context.Document3CurriculumDistributions
                  .FindAsync(item.Document3Id, item.CurriculumId);

                if (existingItem != null)
                {
                    _context.Document3CurriculumDistributions.Remove(existingItem);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteDocument3CurriculumDistributionByDoc3Id(int id)
        {
            var items = await _context.Document3CurriculumDistributions
                .Where(x => x.Document3Id == id).ToListAsync();
            if (items != null)
            {
                _context.RemoveRange(items);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Document3CurriculumDistribution>> GetCurriculumDistributionByDocument1Id(int doc1d)
        {
            var cd = await _context.Document3CurriculumDistributions
                .Include(x => x.Document3)
                .Include(x => x.Curriculum)
                 .Where(x => x.Document3.Document1Id == doc1d)
                 .ToListAsync();
            return cd;
        }

        public async Task<IEnumerable<Document3CurriculumDistribution>> GetCurriculumDistributionByDocument3Id(int doc3Id)
        {
            var cd = await _context.Document3CurriculumDistributions
                .Include(x => x.Document3)
                .Include(x => x.Curriculum)
                 .Where(x => x.Document3Id == doc3Id)
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
                        throw new Exception("Curriculum Distribution Id is not Exist");
                    }

                    var equipment = await _context.TeachingEquipments
                        .FindAsync(item.EquipmentId);
                    if (equipment == null)
                    {
                        throw new Exception("Teaching Equipments Id is not Exist");
                    }
                    var room = await _context.SubjectRooms
                        .FindAsync(item.SubjectRoomId);
                    if (room == null)
                    {
                        throw new Exception("Subject Room Id is not Exist");
                    }

                    var existingItem = await _context.Document3CurriculumDistributions
                        .FindAsync(item.Document3Id, curriculum.Id, equipment.Id, room.Id);
                    if (existingItem == null)
                    {
                        var newItem = new Document3CurriculumDistribution
                        {
                            Document3Id = item.Document3Id,
                            CurriculumId = curriculum.Id,
                            EquipmentId = equipment.Id,
                            SubjectRoomId = room.Id,
                            Slot = item.Slot,
                            Time = item.Time
                        };
                        _context.Document3CurriculumDistributions.Add(newItem);
                    }
                    else
                    {
                        existingItem.Slot = item.Slot;
                        existingItem.Time = item.Time;
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
