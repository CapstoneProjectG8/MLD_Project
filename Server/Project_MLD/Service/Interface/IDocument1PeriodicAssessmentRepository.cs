using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument1PeriodicAssessmentsRepository
    {
        Task<IEnumerable<Document1PeriodicAssessment>> GetAllDocument1PeriodicAssessments();
        Task<IEnumerable<Document1PeriodicAssessment>> GetDocument1PeriodicAssessmentsByDocument1Id(int id);
        Task UpdateDocument1PeriodicAssessments(List<Document1PeriodicAssessment> dc);
        Task DeletePeriodicAssessments(List<Document1PeriodicAssessment> dc);
        Task DeletePeriodicAssessmentsByDoc1ID(int id);

        Task<IEnumerable<TestingCategory>> GetAllTestingCategory();
        Task<TestingCategory> GetTestingCategoryById(int id);
        Task<IEnumerable<FormCategory>> GetAllFormCategory();
        Task<FormCategory> GetFormCategoryById(int id);
    }
}
