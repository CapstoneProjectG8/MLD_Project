using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface ILevelOfTrainningRepository
    {
        Task<IEnumerable<LevelOfTrainning>> GetAllLevelOfTrainnings();
        Task<LevelOfTrainning> GetLevelOfTrainningById(int id);
        Task<LevelOfTrainning> AddLevelOfTrainning(LevelOfTrainning lt);
        Task<bool> UpdateLevelOfTrainning(LevelOfTrainning lt);
        Task<bool> DeleteLevelOfTrainning(int id);

    }
}
