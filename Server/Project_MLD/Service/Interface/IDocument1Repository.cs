using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument1Repository
    {
        Task<IEnumerable<Document1>> GetAllDocument1s();
        Task<Document1> GetDocument1ById(int id);
        Task<Document1> AddDocument1(Document1 document1);
        Task<bool> UpdateDocument1(Document1 document1);
        Task<bool> DeleteDocument1(int id);
        Task<IEnumerable<Document1>> FilterDocument1(int gradeId, int subjectId);
        Task<IEnumerable<Document1>> GetDocument1ByApprovalID(int id);
        Task<IEnumerable<Document1>> GetAllDocument1sByUserIdAndApproveId(int id, int approveId);
        Task<IEnumerable<object>> GetDocument1ByUserSpecialiedDepartment(List<int> listSpecialiedDepartmentID);
    }
}
