using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument1PeriodicAssessmentsRepository
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

        Task<bool> UpdateTestingCategory(TestingCategory tc);
        Task<bool> UpdateFormCategory(FormCategory tc);
    }
}
