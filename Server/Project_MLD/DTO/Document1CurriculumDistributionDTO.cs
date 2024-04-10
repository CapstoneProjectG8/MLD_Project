using Project_MLD.Models;

namespace Project_MLD.DTO
{
    public class Document1CurriculumDistributionDTO
    {
        public int Document1Id { get; set; }
        public int CurriculumId { get; set; }
        public int Slot { get; set; }
        public string? Description { get; set; }
        public string? CurriculumName { get; set; }
    }
}
