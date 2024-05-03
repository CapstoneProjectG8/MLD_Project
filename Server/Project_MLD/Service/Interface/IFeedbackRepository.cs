using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Report>> GetAllFeedbacks();
        Task<Report> GetFeedbackById(int id);
        Task<Report> AddFeedback(Report cl);
        Task<bool> UpdateFeedback(Report cl);

    }
}
