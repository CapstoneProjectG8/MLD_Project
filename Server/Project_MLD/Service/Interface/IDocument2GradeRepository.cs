using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument2GradeRepository
    {
        Task<IEnumerable<Document2Grade>> GetAllDocuemnt2Grades();
        Task<Document2Grade> GetDocument2GradeById(int id);
        Task<Document2Grade> AddDocument2Grade(Document2Grade Document2ByGrade);
        Task<bool> UpdateDocument2Grade(Document2Grade Document2ByGrade);
        Task<bool> DeleteDocument2Grade(int id);

    }
}
