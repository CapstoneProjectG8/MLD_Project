using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument3SelectedTopicsRepository
    {
        Task<IEnumerable<Document3SelectedTopic>> GetDocument3SelectedTopicsByDocument3Id(int doc3Id);
        Task<IEnumerable<Document3SelectedTopic>> GetDocument3SelectedTopicsByDocument1Id(int doc1Id);
        Task UpdateDocument3SelectedTopics(List<Document3SelectedTopic> dc);
        Task DeleteDocument3SelectedTopics(List<Document3SelectedTopic> dc);
        Task DeleteDocument3SelectedTopicsbyDoc3Id(int id);
        Task<Document3SelectedTopic> AddDoc3SelectedTopics(Document3SelectedTopic st);
    }
}
