namespace Project_MLD.DTO
{
    public class AccountDTO
    {
        public int? AccountId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool? Active { get; set; }
        public string? CreatedBy { get; set; }
        public DateOnly? CreatedDate { get; set; }
        public int? RoleId { get; set; }
    }
}
