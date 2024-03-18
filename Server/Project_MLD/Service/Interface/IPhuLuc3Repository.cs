using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IPhuLuc3Repository
    {
        Task<IEnumerable<PhuLuc3>> GetAllPhuLuc3s();
        Task<PhuLuc3> GetPhuLuc3ById(int id);
        Task<PhuLuc3> AddPhuLuc3(PhuLuc3 pl3);
        Task<bool> UpdatePhuLuc3(PhuLuc3 pl3);
        Task<bool> DeletePhuLuc3(int id);

    }
}
