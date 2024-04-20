using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System;

namespace Project_MLD.Service.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly MldDatabaseContext _context;

        public FeedbackRepository(MldDatabaseContext context)
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
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task<Feedback> GetFeedbackById(int id)
        {
            return await _context.Feedbacks.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
