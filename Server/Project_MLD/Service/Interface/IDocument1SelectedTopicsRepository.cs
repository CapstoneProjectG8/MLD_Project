using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument1SelectedTopicsRepository
    {
        Task<IEnumerable<Document1SelectedTopic>> GetSelectedTopicByDocument1Id(int id);
        Task AddDocument1SelectedTopic(List<Document1SelectedTopic> dc);
        Task DeleteDocument1SelectedTopic(List<Document1SelectedTopic> dc);
        Task DeleteDocument1SelectedTopicByDoc1Id(int docId);
    }
}
