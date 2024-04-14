using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project_MLD.Models;

public partial class MldDatabaseContext : DbContext
{
    public MldDatabaseContext()
    {
    }

    public MldDatabaseContext(DbContextOptions<MldDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<CurriculumDistribution> CurriculumDistributions { get; set; }

    public virtual DbSet<Doc> Docs { get; set; }

    public virtual DbSet<Document1> Document1s { get; set; }

    public virtual DbSet<Document1CurriculumDistribution> Document1CurriculumDistributions { get; set; }

    public virtual DbSet<Document1SelectedTopic> Document1SelectedTopics { get; set; }

    public virtual DbSet<Document1SubjectRoom> Document1SubjectRooms { get; set; }

    public virtual DbSet<Document1TeachingEquipment> Document1TeachingEquipments { get; set; }

    public virtual DbSet<Document2> Document2s { get; set; }

    public virtual DbSet<Document2Grade> Document2Grades { get; set; }

    public virtual DbSet<Document3> Document3s { get; set; }

    public virtual DbSet<Document3CurriculumDistribution> Document3CurriculumDistributions { get; set; }

    public virtual DbSet<Document3SelectedTopic> Document3SelectedTopics { get; set; }

    public virtual DbSet<Document4> Document4s { get; set; }

    public virtual DbSet<Document5> Document5s { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FormCategory> FormCategories { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<LevelOfTrainning> LevelOfTrainnings { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<PeriodicAssessment> PeriodicAssessments { get; set; }

    public virtual DbSet<ProfessionalStandard> ProfessionalStandards { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SelectedTopic> SelectedTopics { get; set; }

    public virtual DbSet<SpecializedDepartment> SpecializedDepartments { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectRoom> SubjectRooms { get; set; }

    public virtual DbSet<TeachingEquipment> TeachingEquipments { get; set; }

    public virtual DbSet<TeachingPlanner> TeachingPlanners { get; set; }

    public virtual DbSet<TestingCategory> TestingCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_100_CI_AS_SC_UTF8");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedBy)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.Password)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Username)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Account_Role1");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Lớp");

            entity.ToTable("Class");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GradeId).HasColumnName("grade_ id");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");

            entity.HasOne(d => d.Grade).WithMany(p => p.Classes)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK_Class_Grade");
        });

        modelBuilder.Entity<CurriculumDistribution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Phân phối chương trình");

            entity.ToTable("Curriculum Distribution");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Doc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Document");

            entity.ToTable("Doc");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Document4Id).HasColumnName("document4_id");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");

            entity.HasOne(d => d.Category).WithMany(p => p.Docs)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doc_Category");

            entity.HasOne(d => d.Document4).WithMany(p => p.Docs)
                .HasForeignKey(d => d.Document4Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doc_Document 4");
        });

        modelBuilder.Entity<Document1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Kế Hoạch Dạy Học");

            entity.ToTable("Document 1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApproveBy).HasColumnName("approve_by");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.IsApprove).HasColumnName("isApprove");
            entity.Property(e => e.LinkFile).HasColumnName("link_file");
            entity.Property(e => e.LinkImage).HasColumnName("link_image");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.Note)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("note");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Grade).WithMany(p => p.Document1s)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK_Document 1_Grade");

            entity.HasOne(d => d.Subject).WithMany(p => p.Document1s)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_Document 1_Subject");

            entity.HasOne(d => d.User).WithMany(p => p.Document1s)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Phu Luc 1_User");
        });

        modelBuilder.Entity<Document1CurriculumDistribution>(entity =>
        {
            entity.HasKey(e => new { e.Document1Id, e.CurriculumId });

            entity.ToTable("Document1_CurriculumDistribution");

            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.CurriculumId).HasColumnName("curriculum_id");
            entity.Property(e => e.Description)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("description");
            entity.Property(e => e.Slot).HasColumnName("slot");

            entity.HasOne(d => d.Curriculum).WithMany(p => p.Document1CurriculumDistributions)
                .HasForeignKey(d => d.CurriculumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document1_CurriculumDistribution_Curriculum Distribution");

            entity.HasOne(d => d.Document1).WithMany(p => p.Document1CurriculumDistributions)
                .HasForeignKey(d => d.Document1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document1_CurriculumDistribution_Document 1");
        });

        modelBuilder.Entity<Document1SelectedTopic>(entity =>
        {
            entity.HasKey(e => new { e.Document1Id, e.SelectedTopicsId });

            entity.ToTable("Document1_SelectedTopics");

            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.SelectedTopicsId).HasColumnName("selected_topics_id");
            entity.Property(e => e.Description)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("description");
            entity.Property(e => e.Slot).HasColumnName("slot");

            entity.HasOne(d => d.Document1).WithMany(p => p.Document1SelectedTopics)
                .HasForeignKey(d => d.Document1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document1_SelectedTopics_Document 1");

            entity.HasOne(d => d.SelectedTopics).WithMany(p => p.Document1SelectedTopics)
                .HasForeignKey(d => d.SelectedTopicsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document1_SelectedTopics_Selected Topics");
        });

        modelBuilder.Entity<Document1SubjectRoom>(entity =>
        {
            entity.HasKey(e => new { e.SubjectRoomId, e.Document1Id });

            entity.ToTable("Document1_Subject Room");

            entity.Property(e => e.SubjectRoomId).HasColumnName("subject_room_id");
            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.Description)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("description");
            entity.Property(e => e.Note)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("note");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Document1).WithMany(p => p.Document1SubjectRooms)
                .HasForeignKey(d => d.Document1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document1_Subject Room_Document 1");

            entity.HasOne(d => d.SubjectRoom).WithMany(p => p.Document1SubjectRooms)
                .HasForeignKey(d => d.SubjectRoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document1_Subject Room_Subject Room");
        });

        modelBuilder.Entity<Document1TeachingEquipment>(entity =>
        {
            entity.HasKey(e => new { e.Document1Id, e.TeachingEquipmentId });

            entity.ToTable("Document1_TeachingEquipment");

            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.TeachingEquipmentId).HasColumnName("teaching_equipment_id");
            entity.Property(e => e.Description)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("description");
            entity.Property(e => e.Note)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("note");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Document1).WithMany(p => p.Document1TeachingEquipments)
                .HasForeignKey(d => d.Document1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document1_TeachingEquipment_Document 1");

            entity.HasOne(d => d.TeachingEquipment).WithMany(p => p.Document1TeachingEquipments)
                .HasForeignKey(d => d.TeachingEquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document1_TeachingEquipment_Teaching Equipment");
        });

        modelBuilder.Entity<Document2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Kế hoạch Tổ chức Hoạt Động Giáo Dục");

            entity.ToTable("Document 2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApproveBy).HasColumnName("approve_by");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.IsApprove).HasColumnName("isApprove");
            entity.Property(e => e.LinkFile).HasColumnName("link_file");
            entity.Property(e => e.LinkImage).HasColumnName("link_image");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Document2s)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Kế hoạch Tổ chức Hoạt Động Giáo Dục_User");
        });

        modelBuilder.Entity<Document2Grade>(entity =>
        {
            entity.HasKey(e => new { e.Document2Id, e.GradeId });

            entity.ToTable("Document2_Grade");

            entity.Property(e => e.Document2Id).HasColumnName("document2_id");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.CollaborateWith)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("collaborate_with");
            entity.Property(e => e.Condition)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("condition");
            entity.Property(e => e.Description)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("description");
            entity.Property(e => e.HostBy)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("host_by");
            entity.Property(e => e.Place)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("place");
            entity.Property(e => e.Slot).HasColumnName("slot");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.TitleName)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("title_name");

            entity.HasOne(d => d.Document2).WithMany(p => p.Document2Grades)
                .HasForeignKey(d => d.Document2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document2_Grade_Document 2");

            entity.HasOne(d => d.Grade).WithMany(p => p.Document2Grades)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document2_Grade_Grade");
        });

        modelBuilder.Entity<Document3>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Kế hoạch giáo dục của GV");

            entity.ToTable("Document 3");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApproveBy).HasColumnName("approve_by");
            entity.Property(e => e.ClaasName).HasColumnName("claas_name");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.IsApprove).HasColumnName("isApprove");
            entity.Property(e => e.LinkFile).HasColumnName("link_file");
            entity.Property(e => e.LinkImage).HasColumnName("link_image");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.OtherTasks).HasColumnName("other_tasks");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Document1).WithMany(p => p.Document3s)
                .HasForeignKey(d => d.Document1Id)
                .HasConstraintName("FK_Document 3_Document 1");

            entity.HasOne(d => d.User).WithMany(p => p.Document3s)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Document 3_User");
        });

        modelBuilder.Entity<Document3CurriculumDistribution>(entity =>
        {
            entity.HasKey(e => new { e.Document3Id, e.CurriculumId, e.EquipmentId });

            entity.ToTable("Document3_CurriculumDistribution");

            entity.Property(e => e.Document3Id).HasColumnName("document3_id");
            entity.Property(e => e.CurriculumId).HasColumnName("curriculum_id");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.Slot).HasColumnName("slot");
            entity.Property(e => e.SubjectRoomName).HasColumnName("subject_room_name");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.Curriculum).WithMany(p => p.Document3CurriculumDistributions)
                .HasForeignKey(d => d.CurriculumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document3_CurriculumDistribution_Curriculum Distribution");

            entity.HasOne(d => d.Document3).WithMany(p => p.Document3CurriculumDistributions)
                .HasForeignKey(d => d.Document3Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document3_CurriculumDistribution_Document 3");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Document3CurriculumDistributions)
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document3_CurriculumDistribution_Teaching Equipment");
        });

        modelBuilder.Entity<Document3SelectedTopic>(entity =>
        {
            entity.HasKey(e => new { e.Document3Id, e.SelectedTopicsId, e.EquipmentId });

            entity.ToTable("Document3_SelectedTopics");

            entity.Property(e => e.Document3Id).HasColumnName("document3_id");
            entity.Property(e => e.SelectedTopicsId).HasColumnName("selectedTopics_id");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.Slot).HasColumnName("slot");
            entity.Property(e => e.SubjectRoomName).HasColumnName("subject_room_name");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.Document3).WithMany(p => p.Document3SelectedTopics)
                .HasForeignKey(d => d.Document3Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document3_SelectedTopics_Document 3");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Document3SelectedTopics)
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document3_SelectedTopics_Teaching Equipment");

            entity.HasOne(d => d.SelectedTopics).WithMany(p => p.Document3SelectedTopics)
                .HasForeignKey(d => d.SelectedTopicsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document3_SelectedTopics_Selected Topics");
        });

        modelBuilder.Entity<Document4>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Phu Luc 4");

            entity.ToTable("Document 4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("created_date");
            entity.Property(e => e.LinkFile).HasColumnName("link_file");
            entity.Property(e => e.LinkImage).HasColumnName("link_image");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TeachingPlannerId).HasColumnName("teaching_planner_id");

            entity.HasOne(d => d.TeachingPlanner).WithMany(p => p.Document4s)
                .HasForeignKey(d => d.TeachingPlannerId)
                .HasConstraintName("FK_Document 4_Teaching Planner");
        });

        modelBuilder.Entity<Document5>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Phu Luc 5");

            entity.ToTable("Document 5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("created_date");
            entity.Property(e => e.Document4Id).HasColumnName("document4_id");
            entity.Property(e => e.LinkFile).HasColumnName("link_file");
            entity.Property(e => e.LinkImage).HasColumnName("link_image");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Document4).WithMany(p => p.Document5s)
                .HasForeignKey(d => d.Document4Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document 5_Document 4");

            entity.HasOne(d => d.User).WithMany(p => p.Document5s)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Document 5_User");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.ToTable("Feedback");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Content)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("content");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Feedback_User");
        });

        modelBuilder.Entity<FormCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Hình thức thi");

            entity.ToTable("Form Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Khối Lớp");

            entity.ToTable("Grade");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
            entity.Property(e => e.TotalStudent).HasColumnName("total_student");
            entity.Property(e => e.TotalStudentSelectedTopics).HasColumnName("total_student_selected_topics");
        });

        modelBuilder.Entity<LevelOfTrainning>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LevelOfTrainning");

            entity.ToTable("Level Of Trainning");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.TitleName).HasColumnName("title_name");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Notification_User");
        });

        modelBuilder.Entity<PeriodicAssessment>(entity =>
        {
            entity.HasKey(e => new { e.TestingCategoryId, e.FormCategoryId, e.Document1Id });

            entity.ToTable("Periodic Assessment");

            entity.Property(e => e.TestingCategoryId).HasColumnName("testing_category_id");
            entity.Property(e => e.FormCategoryId).HasColumnName("form_category_id");
            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("description");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.Document1).WithMany(p => p.PeriodicAssessments)
                .HasForeignKey(d => d.Document1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Periodic Assessment_Document 1");

            entity.HasOne(d => d.FormCategory).WithMany(p => p.PeriodicAssessments)
                .HasForeignKey(d => d.FormCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Periodic Assessment_Form Category");

            entity.HasOne(d => d.TestingCategory).WithMany(p => p.PeriodicAssessments)
                .HasForeignKey(d => d.TestingCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Periodic Assessment_Testing Category");
        });

        modelBuilder.Entity<ProfessionalStandard>(entity =>
        {
            entity.ToTable("Professional Standards");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.RoleName)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<SelectedTopic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Chuyên đề / Bài Học");

            entity.ToTable("Selected Topics");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
        });

        modelBuilder.Entity<SpecializedDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Tổ chuyên Môn");

            entity.ToTable("Specialized Department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Môn học");

            entity.ToTable("Subject");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
        });

        modelBuilder.Entity<SubjectRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Phòng Bộ Môn");

            entity.ToTable("Subject Room");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
        });

        modelBuilder.Entity<TeachingEquipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Thiết bị dậy học");

            entity.ToTable("Teaching Equipment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
        });

        modelBuilder.Entity<TeachingPlanner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User - Lớp - Mon");

            entity.ToTable("Teaching Planner");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Class).WithMany(p => p.TeachingPlanners)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_Teaching Planner_Class");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeachingPlanners)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_Teaching Planner_Subject");

            entity.HasOne(d => d.User).WithMany(p => p.TeachingPlanners)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Teaching Planner_User");
        });

        modelBuilder.Entity<TestingCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Loại Bài kiểm tra");

            entity.ToTable("Testing Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Address)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CreatedBy)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.Email)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("first_name");
            entity.Property(e => e.FullName)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("full_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.LastName)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("last_name");
            entity.Property(e => e.LevelOfTrainningId).HasColumnName("level_of_trainning_id");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate).HasColumnName("modified_date");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.PlaceOfBirth)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("place_of_birth");
            entity.Property(e => e.ProfessionalStandardsId).HasColumnName("professional_standards_id");
            entity.Property(e => e.SpecializedDepartmentId).HasColumnName("specialized_department_id");

            entity.HasOne(d => d.Account).WithMany(p => p.Users)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_User_Account");

            entity.HasOne(d => d.LevelOfTrainning).WithMany(p => p.Users)
                .HasForeignKey(d => d.LevelOfTrainningId)
                .HasConstraintName("FK_User_Level Of Trainning");

            entity.HasOne(d => d.ProfessionalStandards).WithMany(p => p.Users)
                .HasForeignKey(d => d.ProfessionalStandardsId)
                .HasConstraintName("FK_User_Professional Standards");

            entity.HasOne(d => d.SpecializedDepartment).WithMany(p => p.Users)
                .HasForeignKey(d => d.SpecializedDepartmentId)
                .HasConstraintName("FK_User_Specialized Department");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
