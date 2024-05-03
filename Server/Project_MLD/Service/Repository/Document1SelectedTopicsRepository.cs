using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;
using System.Collections.Generic;

namespace Project_MLD.Service.Repository
{
    public class Document1SelectedTopicsRepository : IDocument1SelectedTopicsRepository
    {
        private readonly MldDatabaseContext2 _context;

        public Document1SelectedTopicsRepository(MldDatabaseContext2 context)
        {
            _context = context;
        }

        public async Task DeleteDocument1SelectedTopic(List<Document1SelectedTopic> list)
        {
            if (list == null || !list.Any())
            {
                return; // Nothing to delete
            }

            foreach (var item in list)
            {
                var existingItem = await _context.Document1SelectedTopics
                  .FindAsync(item.Document1Id, item.SelectedTopicsId);

                if (existingItem != null)
                {
                    _context.Document1SelectedTopics.Remove(existingItem);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteDocument1SelectedTopicByDoc1Id(int docId)
        {
            var items = await _context.Document1SelectedTopics
                .Where(x => x.Document1Id == docId).ToListAsync();
            if (items != null)
            {
                _context.RemoveRange(items);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Document1SelectedTopic>> GetSelectedTopicByDocument1Id(int id)
        {
            var st = await _context.Document1SelectedTopics
                .Include(x => x.Document1)
                .Include(x => x.SelectedTopics)
                .Where(x => x.Document1Id == id)
                .ToListAsync();
            return st;
        }

        public async Task UpdateDocument1SelectedTopic(List<Document1SelectedTopic> list)
        {
            try
            {
                foreach (var item in list)
                {
                    var existSelectedTopics = await _context.SelectedTopics
                        .FindAsync(item.SelectedTopicsId);
                    if (existSelectedTopics == null)
                    {
                        existSelectedTopics = new SelectedTopic
                        {
                            Name = item.SelectedTopics.Name
                        };
                        _context.SelectedTopics.Add(existSelectedTopics);
                        _context.SaveChanges();
                        //throw new Exception("Selected Topics Id is not Exist");
                    }
                    var existDocument1SelectedTopics = await _context.Document1SelectedTopics
                        .FindAsync(item.Document1Id, existSelectedTopics.Id);
                    if (existDocument1SelectedTopics == null)
                    {
                        var newItem = new Document1SelectedTopic
                        {
                            Document1Id = item.Document1Id,
                            SelectedTopicsId = existSelectedTopics.Id,
                            Slot = item.Slot,
                            Description = item.Description
                        };
                        _context.Document1SelectedTopics.Add(newItem);
                    }
                    else
                    {
                        existDocument1SelectedTopics.Slot = item.Slot;
                        existDocument1SelectedTopics.Description = item.Description;
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
