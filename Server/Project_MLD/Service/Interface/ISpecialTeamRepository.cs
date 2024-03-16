using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface ISpecialTeamRepository
    {
        Task<IEnumerable<SpecializedTeam>> GetAllSpecialTeams();
        Task<SpecializedTeam> GetSpecialTeamById(int id);
        Task<SpecializedTeam> AddSpecialTeam(SpecializedTeam st);
        Task<bool> UpdateSpecialTeam(SpecializedTeam st);
        Task<bool> DeleteSpecialTeam(int id);

    }
}
