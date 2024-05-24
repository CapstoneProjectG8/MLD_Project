using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAllSubjects();
        Task<Subject> GetSubjectById(int id);
        Task<Subject> AddSubject(Subject sub);
        Task<bool> UpdateSubject(Subject sub);
        Task<bool> DeleteSubject(int id);
        Task<IEnumerable<Subject>> GetSubjectsByDepartmentId(int departmentId);

    }
}
