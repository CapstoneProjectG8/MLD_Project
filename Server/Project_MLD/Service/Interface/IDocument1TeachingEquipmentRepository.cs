using Project_MLD.Models;

namespace Project_MLD.Service.Interface
{
    public interface IDocument1TeachingEquipmentRepository
    {
        Task<IEnumerable<Document1TeachingEquipment>> GetTeachingEquipmentByDocument1Id(int id);
        Task AddDocument1TeachingEquipment(List<Document1TeachingEquipment> list);
        Task DeleteDocument1TeachingEquipment(List<Document1TeachingEquipment> list);
        Task DeleteDocument1TeachingEquipmentByDoc1ID(int id);
    }
}
