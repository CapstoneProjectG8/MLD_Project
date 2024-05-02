using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetAllReports();
        Task<Report> GetReportById(int id);
        Task<Report> AddReport(Report cl);
        Task<bool> UpdateReport(Report cl);

    }
}
