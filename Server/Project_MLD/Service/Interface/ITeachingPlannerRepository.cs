

using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface ITeachingPlannerRepository
    {
        Task<IEnumerable<TeachingPlanner>> GetAllTeachingPlanner();
        Task<IEnumerable<TeachingPlanner>> GetTeachingPlannerByUserId(int userId);
        Task<IEnumerable<TeachingPlanner>> GetTeachingPlannerByClassId(int classId);
        Task<IEnumerable<TeachingPlanner>> GetTeachingPlannerBySubjectId(int subjectId);
        Task<TeachingPlanner> GetTeachingPlannerById(int id);
        Task<bool> DeleteTeachingPlanner(int id);
        Task UpdateTeachingPlannerByUserId(List<TeachingPlanner> mapRequests);
    }
}
