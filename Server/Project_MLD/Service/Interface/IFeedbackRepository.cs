using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetAllFeedbacks();
        Task<Feedback> GetFeedbackById(int id);
        Task<Feedback> AddFeedback(Feedback cl);
        Task<bool> UpdateFeedback(Feedback cl);

    }
}
