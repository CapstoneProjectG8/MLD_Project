using Project_MLD.Models;

namespace Project_MLD.DTO
{
    public class Document1TeachingEquipmentsDTO
    {
        public int Document1Id { get; set; }
        public int TeachingEquipmentId { get; set; }
        public int? Quantity { get; set; }
        public string? Note { get; set; }
        public string? Description { get; set; }
        public string? TeachingEquipmentName { get; set; }
    }
}
