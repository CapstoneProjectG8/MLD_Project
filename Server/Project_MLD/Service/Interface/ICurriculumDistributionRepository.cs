using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface ICurriculumDistributionRepository
    {
        Task<IEnumerable<CurriculumDistribution>> GetAllCurriculumDistributions();
        Task<CurriculumDistribution> GetCurriculumDistributionById(int id);
        Task<CurriculumDistribution> AddCurriculumDistribution(CurriculumDistribution cd);
        Task<bool> UpdateCurriculumDistribution(CurriculumDistribution cd);
        Task<bool> DeleteCurriculumDistribution(int id);

    }
}
