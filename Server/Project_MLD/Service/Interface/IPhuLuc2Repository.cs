using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IPhuLuc2Repository
    {
        Task<IEnumerable<PhuLuc2>> GetAllPhuLuc2s();
        Task<PhuLuc2> GetPhuLuc2ById(int id);
        Task<PhuLuc2> AddPhuLuc2(PhuLuc2 pl2);
        Task<bool> UpdatePhuLuc2(PhuLuc2 pl2);
        Task<bool> DeletePhuLuc2(int id);

    }
}
