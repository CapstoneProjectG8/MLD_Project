using Project_MLD.Models;

namespace Project_MLD.DTO
{
    public class NotificationDTO
    {
        public int Id { get; set; }

        public string? TitleName { get; set; }

        public int SentBy { get; set; }

        public int? ReceiveBy { get; set; }

        public string? Message { get; set; }

        public int? DocType { get; set; }

        public int? DocId { get; set; }

        public string? SentByName { get; set; }
        public string? ReceiveByName { get; set; }
    }
}
