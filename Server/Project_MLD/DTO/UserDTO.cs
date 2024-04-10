using Project_MLD.Models;

namespace Project_MLD.DTO
{
    public class UserDTO
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? FullName { get; set; }

        public byte[]? Photo { get; set; }

        public string? Address { get; set; }

        public bool? Gender { get; set; }

        public string? PlaceOfBirth { get; set; }

        public int? Age { get; set; }

        public int? LevelOfTrainningId { get; set; }

        public int? SpecializedDepartmentId { get; set; }

        public int? AccountId { get; set; }

        public int? ProfessionalStandardsId { get; set; }

        public int? CreatedBy { get; set; }

        public DateOnly? CreatedDate { get; set; }

        public bool? Active { get; set; }

    }
}
