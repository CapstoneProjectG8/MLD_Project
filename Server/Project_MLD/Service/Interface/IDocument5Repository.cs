using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument5Repository
    {
        Task<IEnumerable<Document5>> GetAllDocument5s();
        Task<Document5> GetDocument5ById(int id);
        Task<Document5> AddDocument5(Document5 pl5);
        Task<bool> UpdateDocument5(Document5 pl5);
        Task<bool> DeleteDocument5(int id);
        Task<IEnumerable<Document5>> GetDocument5sByCondition(string condition);
        Task<IEnumerable<Document5>> GetDoucment5ByDoc4(int id);
    }
}
