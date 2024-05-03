using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;
using System.Data;

namespace Project_MLD.Service.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly MldDatabaseContext2 _context;

        public FeedbackRepository(MldDatabaseContext2 context)
        {
            _context = context;
        }

        public async Task<Feedback> AddFeedback(Feedback cl)
        {
            _context.Feedbacks.Add(cl);
            await _context.SaveChangesAsync();
            return cl;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacks()
        {
            return await _context.Feedbacks.OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<Feedback> GetFeedbackById(int id)
        {
            return await _context.Feedbacks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateFeedback(Feedback cl)
        {
            var existFB = await _context.Feedbacks.FindAsync(cl.Id);
            if (existFB == null)
            {
                return false;
            }

            var entityType = typeof(Feedback);
            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                var newValue = property.GetValue(cl);
                if (newValue != null)
                {
                    property.SetValue(existFB, newValue);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
