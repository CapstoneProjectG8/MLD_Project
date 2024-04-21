using AutoMapper.Internal;
using Microsoft.EntityFrameworkCore;
using Project_MLD.Models;
using Project_MLD.Service.Interface;

namespace Project_MLD.Service.Repository
{
    public class TeachingPlannerRepository : ITeachingPlannerRepository
    {
        private readonly MldDatabaseContext _context;

        public TeachingPlannerRepository(MldDatabaseContext context)
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

        public async Task UpdateTeachingPlannerByUserId(List<TeachingPlanner> list)
        {
            try
            {
                foreach (var item in list)
                {
                    var checkExistTeachingPlanner = await _context.TeachingPlanners
                        .Where(x => 
                        x.SubjectId == item.SubjectId 
                        && x.UserId == item.UserId
                        && x.ClassId == item.ClassId).ToListAsync();

                    if (checkExistTeachingPlanner == null)
                    {
                        var newItem = new TeachingPlanner()
                        {
                            UserId = item.UserId,
                            ClassId = item.ClassId,
                            SubjectId = item.SubjectId,
                        };
                        _context.TeachingPlanners.Add(newItem);
                    }
                }
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating Teaching Planner.", ex);
            }
        }

        public async Task<TeachingPlanner> AddTeachingPlanner(int userId, int subjectId, int classId)
        {
            try
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
            }catch (Exception ex)
            {
                throw new Exception("An error occurred while add Teaching Planner.", ex);
            }
           
        }
    }
}
