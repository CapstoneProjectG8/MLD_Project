using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document3SelectedTopicsRepository : IDocument3SelectedTopicsRepository
    {
        private readonly MldDatabaseContext _context;

        public Document3SelectedTopicsRepository(MldDatabaseContext context)
        {
            _context = context;
        }

        public async Task DeleteDocument3SelectedTopics(List<Document3SelectedTopic> list)
        {
            if (list == null || !list.Any())
            {
                return; // Nothing to delete
            }

            foreach (var item in list)
            {
                var existingItem = await _context.Document3SelectedTopics
                  .FindAsync(item.Document3Id, item.SelectedTopicsId);

                if (existingItem != null)
                {
                    _context.Document3SelectedTopics.Remove(existingItem);
                }
            }

            await _context.SaveChangesAsync();
        }

        

        public async Task<IEnumerable<Document3SelectedTopic>> GetDocument3SelectedTopicsByDocument3Id(int id)
        {
            var cd = await _context.Document3SelectedTopics
                .Include(x => x.Document3)
                .Include(x => x.SelectedTopics)
               .Where(x => x.Document3Id == id)
               .ToListAsync();
            return cd;
        }

        public async Task UpdateDocument3SelectedTopics(List<Document3SelectedTopic> list)
        {
            try
            {
                foreach (var item in list)
                {
                    var topics = await _context.SelectedTopics
                        .FindAsync(item.SelectedTopicsId);
                    if (topics == null)
                    {
                        topics = new SelectedTopic
                        {
                            Name = item.SelectedTopics.Name
                        };
                        _context.SelectedTopics.Add(topics);
                        _context.SaveChanges();
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
                        _context.SaveChanges();
                    }

                    var existingItem = await _context.Document3SelectedTopics
                        .FindAsync(item.Document3Id, topics.Id, equipment.Id);
                    if (existingItem == null)
                    {
                        var newItem = new Document3SelectedTopic
                        {
                            Document3Id = item.Document3Id,
                            SelectedTopicsId = topics.Id,
                            EquipmentId = equipment.Id,
                            Slot = item.Slot,
                            Time = item.Time,
                            SubjectRoomName = item.SubjectRoomName
                        };
                        _context.Document3SelectedTopics.Add(newItem);
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
                throw new Exception("An error occurred while updating Selected Topics.", ex);
            }
        }
    }
}
