using Project_MLD.Models;

namespace Project_MLD.DTO
{
    public class FeedbackDTO
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public string? Message { get; set; }

        public int? DocType { get; set; }

        public int? DocId { get; set; }

        public string? Description { get; set; }

        public bool? Read { get; set; }

        public string? UserName { get; set; }

    }
}
