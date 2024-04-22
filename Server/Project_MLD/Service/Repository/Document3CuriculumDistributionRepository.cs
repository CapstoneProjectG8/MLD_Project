using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;
using System.Collections.Generic;

namespace Project_MLD.Service.Repository
{
    public class Document3CuriculumDistributionRepository : IDocument3CurriculumDistributionRepository
    {
        private readonly MldDatabaseContext _context;

        public Document3CuriculumDistributionRepository(MldDatabaseContext context)
        {
            _context = context;
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
            if(items != null)
            {
                _context.RemoveRange(items);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Document3CurriculumDistribution>> GetCurriculumDistributionByDocument3Id(int id)
        {
            var cd = await _context.Document3CurriculumDistributions
                .Include(x => x.Document3)
                .Include(x => x.Curriculum)
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
                        //curriculum = new CurriculumDistribution
                        //{
                        //    Name = item.Curriculum.Name
                        //};
                        //_context.CurriculumDistributions.Add(curriculum);
                        //_context.SaveChanges();
                        throw new Exception("Curriculum Distribution Id is not Exist");
                    }

                    var equipment = await _context.TeachingEquipments
                        .FindAsync(item.EquipmentId);
                    if (equipment == null)
                    {
                        //equipment = new TeachingEquipment
                        //{
                        //    Name = item.Equipment.Name
                        //};
                        //_context.TeachingEquipments.Add(equipment);
                        //_context.SaveChanges();
                        throw new Exception("Teaching Equipments Id is not Exist");
                    }

                    var existingItem = await _context.Document3CurriculumDistributions
                        .FindAsync(item.Document3Id, curriculum.Id, equipment.Id);
                    if (existingItem == null)
                    {
                        var newItem = new Document3CurriculumDistribution
                        {
                            Document3Id = item.Document3Id,
                            CurriculumId = curriculum.Id,
                            EquipmentId = equipment.Id,
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
                throw new Exception(ex.Message);
            }
        }

    }
}
