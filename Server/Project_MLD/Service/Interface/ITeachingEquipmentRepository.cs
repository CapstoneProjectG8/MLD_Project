using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface ITeachingEquipmentRepository
    {
        Task<IEnumerable<TeachingEquipment>> GetAllTeachingEquipments();
        Task<TeachingEquipment> GetTeachingEquipmentById(int id);
        Task<TeachingEquipment> AddTeachingEquipment(TeachingEquipment te);
        Task<bool> UpdateTeachingEquipment(TeachingEquipment te);
        Task<bool> DeleteTeachingEquipment(int id);

    }
}
