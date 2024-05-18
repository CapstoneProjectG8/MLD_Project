using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class Document3SelectedTopicsRepository : IDocument3SelectedTopicsRepository
    {
        private readonly MldDatabase2Context _context;

        public Document3SelectedTopicsRepository(MldDatabase2Context context)
        {
            _context = context;
        }

        public async Task<Document3SelectedTopic> AddDoc3SelectedTopics(Document3SelectedTopic st)
        {
            await _context.Document3SelectedTopics.AddAsync(st);
            await _context.SaveChangesAsync();
            return st;
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

        public async Task DeleteDocument3SelectedTopicsbyDoc3Id(int id)
        {
            var items = await _context.Document3SelectedTopics.Where(x => x.Document3Id == id).ToListAsync();
            if (items != null)
            {
                _context.RemoveRange(items);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Document3SelectedTopic>> GetDocument3SelectedTopicsByDocument1Id(int doc1Id)
        {
            var cd = await _context.Document3SelectedTopics
                .Include(x => x.Document3)
                .Include(x => x.SelectedTopics)
               .Where(x => x.Document3.Document1Id == doc1Id)
               .ToListAsync();
            return cd;
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
    }
}
