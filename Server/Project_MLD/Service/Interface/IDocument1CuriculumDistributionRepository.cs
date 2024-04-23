using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument1CuriculumDistributionRepository
    {
        Task<IEnumerable<Document1CurriculumDistribution>> GetCurriculumDistributionByDocument1Id(int id);
        Task UpdateDocument1CurriculumDistribution(List<Document1CurriculumDistribution> dc);
        Task DeleteDocument1CurriculumDistribution(List<Document1CurriculumDistribution> dc);
        Task DeleteDocument1CurriculumDistributionByDoc1ID(int id);
    }
}
