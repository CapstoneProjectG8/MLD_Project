using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument3Repository
    {
        Task<IEnumerable<Document3>> GetAllDocument3s();
        Task<IEnumerable<Document3>> GetAllDoc3sByDoc1Id(int doc1Id);
        Task<Document3> GetDocument3ById(int id);
        Task<Document3> AddDocument3(Document3 pl3);
        Task<bool> UpdateDocument3(Document3 pl3);
        Task<bool> DeleteDocument3(int id);
        Task<IEnumerable<Document3>> GetAllDoc3sWithCondition(bool? status, int? isApprove);
        Task<IEnumerable<Document3>> GetAllDocument3sByUserIdAndApproveId(int userId, int approveId);
        Task<IEnumerable<object>> GetDocument3ByUserSpecialiedDepartment(List<int> listId);
    }
}
