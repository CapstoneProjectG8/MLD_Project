﻿namespace Project_MLD.DTO
{
    public class AccountDTO
    {
        public int AccountId { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool? Active { get; set; }

        public int? CreatedBy { get; set; }

        public DateOnly? CreatedDate { get; set; }

        public int? RoleId { get; set; }

        public int? LoginAttempt { get; set; }

        public DateTime? LoginLast { get; set; }
    }
}
