using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IPeriodicAssessmentCategoryRepository
    {
        Task<IEnumerable<TestingCategory>> GetAllTestingCategory();
        Task<TestingCategory> GetTestingCategoryById(int id);
        Task<IEnumerable<FormCategory>> GetAllFormCategory();
        Task<FormCategory> GetFormCategoryById(int id);
    }
}
