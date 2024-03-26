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

    public virtual DbSet<Document4> Document4s { get; set; }

    public virtual DbSet<Document5> Document5s { get; set; }

    public virtual DbSet<FormCategory> FormCategories { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<LevelOfTrainning> LevelOfTrainnings { get; set; }

    public virtual DbSet<LoginAttempt> LoginAttempts { get; set; }

    public virtual DbSet<PeriodicAssessment> PeriodicAssessments { get; set; }

    public virtual DbSet<ProfessionalStandard> ProfessionalStandards { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Scorm> Scorms { get; set; }

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
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Account_Role");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Lớp");

            entity.ToTable("Class");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.GradeId).HasColumnName("grade_ id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Grade).WithMany(p => p.Classes)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK_Lớp_Khối Lớp");
        });

        modelBuilder.Entity<CurriculumDistribution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Phân phối chương trình");

            entity.ToTable("Curriculum Distribution");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
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
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Category).WithMany(p => p.Docs)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document_Category");

            entity.HasOne(d => d.Document4).WithMany(p => p.Docs)
                .HasForeignKey(d => d.Document4Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document_Phu Luc 4");
        });

        modelBuilder.Entity<Document1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Kế Hoạch Dạy Học");

            entity.ToTable("Document 1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApproveBy).HasColumnName("approve_by");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Note)
                .HasMaxLength(50)
                .HasColumnName("note");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Grade).WithMany(p => p.Document1s)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK_Kế Hoạch Dạy Học_Khối Lớp");

            entity.HasOne(d => d.Subject).WithMany(p => p.Document1s)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_Kế Hoạch Dạy Học_Môn học");

            entity.HasOne(d => d.User).WithMany(p => p.Document1s)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Phu Luc 1_User");
        });

        modelBuilder.Entity<Document1CurriculumDistribution>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Document1_CurriculumDistribution");

            entity.Property(e => e.CurriculumId).HasColumnName("curriculum_id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.Slot).HasColumnName("slot");

            entity.HasOne(d => d.Curriculum).WithMany()
                .HasForeignKey(d => d.CurriculumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_khdh-pptc_Phân phối chương trình");

            entity.HasOne(d => d.Document1).WithMany()
                .HasForeignKey(d => d.Document1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_khdh-pptc_Kế Hoạch Dạy Học");
        });

        modelBuilder.Entity<Document1SelectedTopic>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Document1_SelectedTopics");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.SelectedTopicsId).HasColumnName("selected_topics_id");
            entity.Property(e => e.Slot).HasColumnName("slot");

            entity.HasOne(d => d.Document1).WithMany()
                .HasForeignKey(d => d.Document1Id)
                .HasConstraintName("FK_khdh _ CD / BH_Kế Hoạch Dạy Học");

            entity.HasOne(d => d.SelectedTopics).WithMany()
                .HasForeignKey(d => d.SelectedTopicsId)
                .HasConstraintName("FK_khdh _ CD / BH_Chuyên đề / Bài Học");
        });

        modelBuilder.Entity<Document1SubjectRoom>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Document1_Subject Room");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.Note)
                .HasMaxLength(50)
                .HasColumnName("note");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SubjectRoomId).HasColumnName("subject_room_id");

            entity.HasOne(d => d.Document1).WithMany()
                .HasForeignKey(d => d.Document1Id)
                .HasConstraintName("FK_khdh - Phòng bộ môn_Kế Hoạch Dạy Học");

            entity.HasOne(d => d.SubjectRoom).WithMany()
                .HasForeignKey(d => d.SubjectRoomId)
                .HasConstraintName("FK_khdh - Phòng bộ môn_Phòng Bộ Môn");
        });

        modelBuilder.Entity<Document1TeachingEquipment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Document1_TeachingEquipment");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.Note)
                .HasMaxLength(50)
                .HasColumnName("note");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TeachingEquipmentId).HasColumnName("teaching_equipment_id");

            entity.HasOne(d => d.Document1).WithMany()
                .HasForeignKey(d => d.Document1Id)
                .HasConstraintName("FK_KHDH_TBDH_Kế Hoạch Dạy Học");

            entity.HasOne(d => d.TeachingEquipment).WithMany()
                .HasForeignKey(d => d.TeachingEquipmentId)
                .HasConstraintName("FK_KHDH_TBDH_Thiết bị dậy học");
        });

        modelBuilder.Entity<Document2>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Kế hoạch Tổ chức Hoạt Động Giáo Dục");

            entity.ToTable("Document 2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Document2s)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Kế hoạch Tổ chức Hoạt Động Giáo Dục_User");
        });

        modelBuilder.Entity<Document2Grade>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Document2_Grade");

            entity.Property(e => e.CollaborateWith)
                .HasMaxLength(50)
                .HasColumnName("collaborate_with");
            entity.Property(e => e.Condition)
                .HasMaxLength(50)
                .HasColumnName("condition");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Document2Id).HasColumnName("document2_id");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.HostBy)
                .HasMaxLength(50)
                .HasColumnName("host_by");
            entity.Property(e => e.Place)
                .HasMaxLength(50)
                .HasColumnName("place");
            entity.Property(e => e.Slot).HasColumnName("slot");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.TitleName)
                .HasMaxLength(50)
                .HasColumnName("title_name");

            entity.HasOne(d => d.Document2).WithMany()
                .HasForeignKey(d => d.Document2Id)
                .HasConstraintName("FK_KHTCHDGD - KHỐI LỚP_Kế hoạch Tổ chức Hoạt Động Giáo Dục");

            entity.HasOne(d => d.Grade).WithMany()
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK_KHTCHDGD - KHỐI LỚP_Khối Lớp");
        });

        modelBuilder.Entity<Document3>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Kế hoạch giáo dục của GV");

            entity.ToTable("Document 3");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Document1).WithMany(p => p.Document3s)
                .HasForeignKey(d => d.Document1Id)
                .HasConstraintName("FK_Kế hoạch giáo dục của GV_Kế Hoạch Dạy Học");

            entity.HasOne(d => d.User).WithMany(p => p.Document3s)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Kế hoạch giáo dục của GV_User");
        });

        modelBuilder.Entity<Document3CurriculumDistribution>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Document3_CurriculumDistribution");

            entity.Property(e => e.CurriculumId).HasColumnName("curriculum_id");
            entity.Property(e => e.Document3Id).HasColumnName("document3_id");
            entity.Property(e => e.Place)
                .HasMaxLength(50)
                .HasColumnName("place");
            entity.Property(e => e.Slot).HasColumnName("slot");
            entity.Property(e => e.TeachingEquipmentId).HasColumnName("teaching_equipment_id");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.Curriculum).WithMany()
                .HasForeignKey(d => d.CurriculumId)
                .HasConstraintName("FK_khgdGV - ppct_Phân phối chương trình");

            entity.HasOne(d => d.Document3).WithMany()
                .HasForeignKey(d => d.Document3Id)
                .HasConstraintName("FK_khgdGV - ppct_Kế hoạch giáo dục của GV");

            entity.HasOne(d => d.TeachingEquipment).WithMany()
                .HasForeignKey(d => d.TeachingEquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_khgdGV - ppct_Thiết bị dậy học");
        });

        modelBuilder.Entity<Document4>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Phu Luc 4");

            entity.ToTable("Document 4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TeachingPlannerId).HasColumnName("teaching_planner_id");

            entity.HasOne(d => d.TeachingPlanner).WithMany(p => p.Document4s)
                .HasForeignKey(d => d.TeachingPlannerId)
                .HasConstraintName("FK_Phu Luc 4_User - Lớp - Mon");
        });

        modelBuilder.Entity<Document5>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Phu Luc 5");

            entity.ToTable("Document 5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Document4Id).HasColumnName("document4_id");
            entity.Property(e => e.EvaluateBy).HasColumnName("evaluate_by");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Document4).WithMany(p => p.Document5s)
                .HasForeignKey(d => d.Document4Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phu Luc 5_Phu Luc 4");

            entity.HasOne(d => d.EvaluateByNavigation).WithMany(p => p.Document5s)
                .HasForeignKey(d => d.EvaluateBy)
                .HasConstraintName("FK_Phu Luc 5_User");
        });

        modelBuilder.Entity<FormCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Hình thức thi");

            entity.ToTable("Form Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Khối Lớp");

            entity.ToTable("Grade");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
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
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<LoginAttempt>(entity =>
        {
            entity.ToTable("Login Attempt");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountName)
                .HasMaxLength(50)
                .HasColumnName("account_name");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Success).HasColumnName("success");
        });

        modelBuilder.Entity<PeriodicAssessment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Periodic Assessment");

            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.FormCategoryId).HasColumnName("form_category_id");
            entity.Property(e => e.TestingCategoryId).HasColumnName("testing_category_id");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.Document1).WithMany()
                .HasForeignKey(d => d.Document1Id)
                .HasConstraintName("FK_Kiểm tra, đánh giá định kỳ_Kế Hoạch Dạy Học");

            entity.HasOne(d => d.FormCategory).WithMany()
                .HasForeignKey(d => d.FormCategoryId)
                .HasConstraintName("FK_Kiểm tra, đánh giá định kỳ_Loại Bài kiểm tra");

            entity.HasOne(d => d.TestingCategory).WithMany()
                .HasForeignKey(d => d.TestingCategoryId)
                .HasConstraintName("FK_Kiểm tra, đánh giá định kỳ_Hình thức thi");
        });

        modelBuilder.Entity<ProfessionalStandard>(entity =>
        {
            entity.ToTable("Professional Standards");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate).HasColumnName("modified_date");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
            entity.Property(e => e.RoleNote)
                .HasMaxLength(50)
                .HasColumnName("role_note");
        });

        modelBuilder.Entity<Scorm>(entity =>
        {
            entity.ToTable("Scorm");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
        });

        modelBuilder.Entity<SelectedTopic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Chuyên đề / Bài Học");

            entity.ToTable("Selected Topics");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<SpecializedDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Tổ chuyên Môn");

            entity.ToTable("Specialized Department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Môn học");

            entity.ToTable("Subject");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<SubjectRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Phòng Bộ Môn");

            entity.ToTable("Subject Room");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TeachingEquipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Thiết bị dậy học");

            entity.ToTable("Teaching Equipment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
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
                .HasConstraintName("FK_GV - Lớp_Lớp");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeachingPlanners)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_User - Lớp - Mon_Môn học1");

            entity.HasOne(d => d.User).WithMany(p => p.TeachingPlanners)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_GV - Lớp_User");
        });

        modelBuilder.Entity<TestingCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Loại Bài kiểm tra");

            entity.ToTable("Testing Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("full_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.LevelOfTrainningId).HasColumnName("level_of_trainning_id");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ModifiedDate).HasColumnName("modified_date");
            entity.Property(e => e.Photo)
                .HasMaxLength(50)
                .HasColumnName("photo");
            entity.Property(e => e.PlaceOfBirth)
                .HasMaxLength(50)
                .HasColumnName("place_of_birth");
            entity.Property(e => e.ProfessionalStandardsId).HasColumnName("professional_standards_id");
            entity.Property(e => e.SpecializedDepartmentId).HasColumnName("specialized_department_id");

            entity.HasOne(d => d.Account).WithMany(p => p.Users)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_User_Account1");

            entity.HasOne(d => d.LevelOfTrainning).WithMany(p => p.Users)
                .HasForeignKey(d => d.LevelOfTrainningId)
                .HasConstraintName("FK_User_LevelOfTrainning");

            entity.HasOne(d => d.ProfessionalStandards).WithMany(p => p.Users)
                .HasForeignKey(d => d.ProfessionalStandardsId)
                .HasConstraintName("FK_User_Professional Standards");

            entity.HasOne(d => d.SpecializedDepartment).WithMany(p => p.Users)
                .HasForeignKey(d => d.SpecializedDepartmentId)
                .HasConstraintName("FK_User_Tổ chuyên Môn");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
