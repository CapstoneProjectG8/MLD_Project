using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetAllGrades();
        Task<Grade> GetGradeById(int id);
        Task<Grade> AddGrade(Grade grade);
        Task<bool> UpdateGrade(Grade grade);
        Task<bool> DeleteGrade(int id);
        Task<int> GetTotalClassByGradeId(int id);
        Task<int> GetTotalStudentByGradeId(int id);
        Task<int> GetTotalStudentSelectedTopicsByGradeId(int id);
    }
}
