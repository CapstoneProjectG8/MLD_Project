using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface ISelectedTopicsRepository
    {
        Task<IEnumerable<SelectedTopic>> GetAllSelectedTopics();
        Task<SelectedTopic> GetSelectedTopicById(int id);
        Task<SelectedTopic> AddSelectedTopic(SelectedTopic st);
        Task<bool> UpdateSelectedTopic(SelectedTopic st);
        Task<bool> DeleteSelectedTopic(int id);

    }
}
