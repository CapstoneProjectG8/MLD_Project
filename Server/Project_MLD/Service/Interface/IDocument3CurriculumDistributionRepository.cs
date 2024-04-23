using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument3CurriculumDistributionRepository
    {
        Task<IEnumerable<Document3CurriculumDistribution>> GetCurriculumDistributionByDocument3Id(int id);
        Task UpdateDocument3CurriculumDistribution(List<Document3CurriculumDistribution> dc);
        Task DeleteDocument3CurriculumDistribution(List<Document3CurriculumDistribution> dc);
        Task DeleteDocument3CurriculumDistributionByDoc3Id(int id);
    }
}
