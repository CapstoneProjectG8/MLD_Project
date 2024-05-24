using AutoMapper.Internal;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;

namespace Project_MLD.Service.Repository
{
    public class TeachingPlannerRepository : ITeachingPlannerRepository
    {
        private readonly MldDatabase2Context _context;

        public TeachingPlannerRepository(MldDatabase2Context context)
        {
            _context = context;
        }

        public async Task<bool> DeleteTeachingPlanner(int id)
        {
            var existTeachingPlanner = await _context.TeachingPlanners.FirstOrDefaultAsync(x => x.Id == id);
            if (existTeachingPlanner != null)
            {
                _context.TeachingPlanners.Remove(existTeachingPlanner);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TeachingPlanner>> GetAllTeachingPlanner()
        {
            return await _context.TeachingPlanners.ToListAsync();
        }

        public async Task<IEnumerable<TeachingPlanner>> GetTeachingPlannerByClassId(int classId)
        {
            return await _context.TeachingPlanners.Where(x => x.ClassId == classId).ToListAsync();

        }

        public async Task<TeachingPlanner> GetTeachingPlannerById(int id)
        {
            return await _context.TeachingPlanners.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TeachingPlanner>> GetTeachingPlannerBySubjectId(int subjectId)
        {
            return await _context.TeachingPlanners.Where(x => x.SubjectId == subjectId).ToListAsync();
        }

        public async Task<IEnumerable<TeachingPlanner>> GetTeachingPlannerByUserId(int userId)
        {
            return await _context.TeachingPlanners.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<TeachingPlanner> AddTeachingPlanner(int userId, int subjectId, int classId)
        {
            try
            {
                var existingTeachingPlanner = _context.TeachingPlanners
                    .Where(x => x.UserId == userId
                    && x.SubjectId == subjectId
                    && x.ClassId == classId)
                    .FirstOrDefault();

                if (existingTeachingPlanner == null)
                {
                    var newItem = new TeachingPlanner()
                    {
                        UserId = userId,
                        SubjectId = subjectId,
                        ClassId = classId
                    };
                    _context.TeachingPlanners.Add(newItem);
                    await _context.SaveChangesAsync();
                    return newItem;
                }
                else
                {
                    return existingTeachingPlanner;
                } 
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while add Teaching Planner.", ex);
            }

        }
    }
}
