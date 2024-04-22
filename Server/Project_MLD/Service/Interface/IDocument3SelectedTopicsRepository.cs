using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument3SelectedTopicsRepository
    {
        Task<IEnumerable<Document3SelectedTopic>> GetDocument3SelectedTopicsByDocument3Id(int id);
        Task UpdateDocument3SelectedTopics(List<Document3SelectedTopic> dc);
        Task DeleteDocument3SelectedTopics(List<Document3SelectedTopic> dc);
        Task DeleteDocument3SelectedTopicsbyDoc3Id(int id);
    }
}
