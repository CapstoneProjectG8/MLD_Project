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

    }
}
