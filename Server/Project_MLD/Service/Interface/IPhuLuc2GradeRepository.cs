using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IPhuLuc2GradeRepository
    {
        Task<IEnumerable<PhuLuc2Grade>> GetAllPhuLuc2Grades();
        Task<PhuLuc2Grade> GetPhuLuc2GradeById(int id);
        Task<PhuLuc2Grade> AddPhuLuc2Grade(PhuLuc2Grade phuLuc2ByGrade);
        Task<bool> UpdatePhuLuc2Grade(PhuLuc2Grade phuLuc2ByGrade);
        Task<bool> DeletePhuLuc2Grade(int id);

    }
}
