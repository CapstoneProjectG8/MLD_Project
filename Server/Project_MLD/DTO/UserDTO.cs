using Project_MLD.Models;

namespace Project_MLD.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Photo { get; set; }

        public string? Address { get; set; }

        public bool? Gender { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public int? Age { get; set; }

        public string? Signature { get; set; }

        public int? LevelOfTrainningId { get; set; }

        public int AccountId { get; set; }

        public int? ProfessionalStandardsId { get; set; }

    }
}
