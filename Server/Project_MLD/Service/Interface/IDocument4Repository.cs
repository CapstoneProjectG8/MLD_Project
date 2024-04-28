using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument4Repository
    {
        Task<IEnumerable<Document4>> GetAllDocument4s();
        Task<IEnumerable<Document4>> GetAllDoc4s();
        Task<Document4> GetDocument4ById(int id);
        Task<Document4> AddDocument4(Document4 pl4);
        Task<bool> UpdateDocument4(Document4 pl4);
        Task<bool> DeleteDocument4(int id);
        Task<IEnumerable<Document4>> GetDocument4sByCondition(string condition);
        Task<IEnumerable<object>> GetDocument4ByUserSpecialiedDepartment(List<int> listId);
        Task<IEnumerable<Document4>> GetDocument4sByUserId(int userId);
        Task<object> GetDoc4InformationByDoc4Id(int id);

    }
}
