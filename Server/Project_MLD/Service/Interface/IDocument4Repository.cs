using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument4Repository
    {
        Task<IEnumerable<Document4>> GetAllDocument4s();
        Task<Document4> GetDocument4ById(int id);
        Task<Document4> GetDoc4TeachingPlannerByDoc4Id(int document4Id);
        Task<Document4> AddDocument4(Document4 pl4);
        Task<bool> UpdateDocument4(Document4 pl4);
        Task<bool> DeleteDocument4(int id);
        Task<IEnumerable<Document4>> GetDocument4sWithCondition(bool? status, int? isApprove);
        Task<IEnumerable<object>> GetDocument4ByUserSpecialiedDepartment(List<int> listId);
        Task<IEnumerable<Document4>> GetDocument4sByUserId(int userId);
        Task<object> GetDoc4InformationByDoc4Id(int id);
        Task<IEnumerable<Document4>> GetDoc4sByDoc3Id(int doc3Id);

    }
}
