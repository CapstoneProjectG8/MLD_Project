using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IEvaluateRepository
    {
        Task<IEnumerable<Evaluate>> GetAllEvaluates();
        Task<Evaluate> GetEvaluateById(int id);
        Task<Evaluate> AddEvaluate(Evaluate eva);
        Task<bool> UpdateEvaluate(Evaluate eva);
        Task<bool> DeleteEvaluate(int id);
    }
}
