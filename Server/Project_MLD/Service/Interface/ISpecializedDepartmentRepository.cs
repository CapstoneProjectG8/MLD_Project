using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface ISpecializedDepartmentRepository
    {
        Task<SpecializedDepartment> GetSpecializedDepartmentById(int id);
        Task<SpecializedDepartment> AddSpecializedDepartment(SpecializedDepartment st);
        Task<bool> UpdateSpecializedDepartment(SpecializedDepartment st);
        Task<bool> DeleteSpecializedDepartment(int id);
        Task<IEnumerable<SpecializedDepartment>> GetAllSpecializedDepartment();
    }
}
