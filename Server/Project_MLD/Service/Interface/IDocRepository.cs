using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocRepository
    {
        Task<IEnumerable<Doc>> GetAllDocs();
        Task<Doc> GetDocById(int id);
        Task<Doc> AddDoc(Doc d);
        Task<bool> DeleteDoc(int id);

    }
}
