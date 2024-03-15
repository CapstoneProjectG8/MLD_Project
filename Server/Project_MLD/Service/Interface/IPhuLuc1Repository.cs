using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IPhuLuc1Repository
    {
        Task<IEnumerable<PhuLuc1>> GetAllPhuLuc1s();
        Task<PhuLuc1> GetPhuLuc1ById(int id);
        Task<PhuLuc1> AddPhuLuc1(PhuLuc1 pl1);
        Task<bool> UpdatePhuLuc1(PhuLuc1 pl1);
        Task<bool> DeletePhuLuc1(int id);

    }
}
