using Project_MLD.Models;

namespace Project_MLD.DTO
{
    public class Document3CurriculumDistributionDTO
    {
        public int Document3Id { get; set; }

        public int CurriculumId { get; set; }

        public int EquipmentId { get; set; }

        public string? SubjectRoomName { get; set; }

        public int? Slot { get; set; }

        public DateOnly? Time { get; set; }
        public string? CurriculumName { get; set; }

        public string? EquipmentName { get; set; }
    }
}
