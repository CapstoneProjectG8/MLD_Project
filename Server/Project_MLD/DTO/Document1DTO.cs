namespace Project_MLD.Models;

public partial class Document1DTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int SubjectId { get; set; }

    public int GradeId { get; set; }

    public int UserId { get; set; }

    public string? Note { get; set; }

    public bool? Status { get; set; }

    public int? ApproveBy { get; set; }

    public int? IsApprove { get; set; }

    public DateOnly? CreatedDate { get; set; }

    public string? LinkFile { get; set; }

    public string? LinkImage { get; set; }

    public string? OtherTasks { get; set; }

    public string? UserFullName { get; set; }
    public string? SubjectName { get; set; }
    public string? GradeName { get; set; }
    public string? ApproveByName { get; set; }

}
