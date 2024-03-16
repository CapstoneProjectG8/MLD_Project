using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IProfessionalStandardRepository
    {
        Task<IEnumerable<ProfessionalStandard>> GetAllProfessionalStandard();
        Task<ProfessionalStandard> GetProfessionalStandardById(int id);
        Task<ProfessionalStandard> AddProfessionalStandard(ProfessionalStandard ps);
        Task<bool> UpdateProfessionalStandard(ProfessionalStandard ps);
        Task<bool> DeleteProfessionalStandard(int id);

    }
}
