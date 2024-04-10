using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument2GradeRepository
    {
        Task<IEnumerable<Document2Grade>> GetAllDocuemnt2Grades();
        Task<IEnumerable<Document2Grade>> GetDocument2GradeByDocument2Id(int id);
        Task UpdateDocument2Grade(List<Document2Grade> list);
        Task DeleteDocument2Grade(List<Document2Grade> list);

    }
}
