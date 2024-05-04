using Project_MLD.Models;

namespace Project_MLD.DTO
{
    public class Document1SelectedTopicsDTO
    {
        public int Id { get; set; }

        public int Document1Id { get; set; }

        public int? SelectedTopicsId { get; set; }

        public int? Slot { get; set; }

        public string? Description { get; set; }

        public string? SelectedTopicsName { get; set; }
    }
}
