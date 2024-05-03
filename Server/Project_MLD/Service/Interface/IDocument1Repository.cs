using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument1Repository
    {
        Task<IEnumerable<Document1>> GetAllDocument1s();
        Task<IEnumerable<Document1>> GetAllDoc1sWithCondition(bool status, int isApprove);
        Task<Document1> GetDocument1ById(int id);
        Task<Document1> AddDocument1(Document1 document1);
        Task<bool> UpdateDocument1(Document1 document1);
        Task<bool> DeleteDocument1(int id);
        Task<IEnumerable<Document1>> FilterAllDoc1(int gradeId, int subjectId);
        Task<IEnumerable<Document1>> GetAllDoc1sByApprovalID(int id);
        Task<IEnumerable<Document1>> GetAllDoc1sByUserIdAndApproveId(int id, int approveId);
        Task<IEnumerable<object>> GetDoc1ByUserDepartment(List<int> listDepartmentID);
    }
}
