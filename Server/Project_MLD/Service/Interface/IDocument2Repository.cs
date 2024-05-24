using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument2Repository
    {
        Task<IEnumerable<Document2>> GetAllDocument2s();
        Task<Document2> GetDocument2ById(int id);
        Task<Document2> AddDocument2(Document2 pl2);
        Task<bool> UpdateDocument2(Document2 pl2);
        Task<bool> DeleteDocument2(int id);
        Task<IEnumerable<Document2>> GetAllDoc2sByCondition(bool? status, int? isApprove);
        Task<IEnumerable<Document2>> GetAllDocument2sByUserIdAndApproveId(int id, int approveId);
        Task<IEnumerable<object>> GetDocument2ByUserSpecialiedDepartment(List<int> specialiedDepartmentListId);
        Task<IEnumerable<Document2>> GetDoc2sByDepId(int depId);
        Task<IEnumerable<int?>> GetListHostbyByIdOfUserByDoc2Id(int doc2Id);
    }
}
