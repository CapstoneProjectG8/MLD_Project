using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetAllClasss();
        Task<Class> GetClassById(int id);
        Task<Class> AddClass(Class cl);
        Task<bool> UpdateClass(Class cl);
        Task<bool> DeleteClass(int id);
        Task<IEnumerable<Class>> GetClassesByGradeId(int gradeId);

    }
}
