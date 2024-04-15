using Project_MLD.Models;

namespace Project_MLD.DTO
{
    public class Document3SelectedTopicDTO
    {
        public int Document3Id { get; set; }

        public int SelectedTopicsId { get; set; }

        public int EquipmentId { get; set; }

        public string? SubjectRoomName { get; set; }

        public int? Slot { get; set; }

        public DateOnly? Time { get; set; }

        public string? SelectedTopicsName { get; set; }

        public string? EquipmentName { get; set; }
    }
}
