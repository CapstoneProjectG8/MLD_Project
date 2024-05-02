using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument1PeriodicAssessmentRepository
    {
        Task<IEnumerable<Document1PeriodicAssessment>> GetAllDocument1PeriodicAssessment();
        Task<IEnumerable<Document1PeriodicAssessment>> GetDocument1PeriodicAssessmentByDocument1Id(int id);
        Task UpdateDocument1PeriodicAssessment(List<Document1PeriodicAssessment> dc);
        Task DeleteDocument1PeriodicAssessment(List<Document1PeriodicAssessment> dc);
        Task DeleteDocument1PeriodicAssessmentByDoc1ID(int id);

        Task<IEnumerable<TestingCategory>> GetAllTestingCategory();
        Task<TestingCategory> GetTestingCategoryById(int id);
        Task<IEnumerable<FormCategory>> GetAllFormCategory();
        Task<FormCategory> GetFormCategoryById(int id);
    }
}
