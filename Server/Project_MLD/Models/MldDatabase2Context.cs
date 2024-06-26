﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project_MLD.Models;

public partial class MldDatabase2Context : DbContext
{
    public MldDatabase2Context()
    {
    }

    public MldDatabase2Context(DbContextOptions<MldDatabase2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<CurriculumDistribution> CurriculumDistributions { get; set; }

    public virtual DbSet<Document1> Document1s { get; set; }

    public virtual DbSet<Document1CurriculumDistribution> Document1CurriculumDistributions { get; set; }

    public virtual DbSet<Document1PeriodicAssessment> Document1PeriodicAssessments { get; set; }

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

    public virtual DbSet<Evaluate> Evaluates { get; set; }

    public virtual DbSet<FormCategory> FormCategories { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<IsApprove> IsApproves { get; set; }

    public virtual DbSet<LevelOfTrainning> LevelOfTrainnings { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<ProfessionalStandard> ProfessionalStandards { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<S3FileMetadatum> S3FileMetadata { get; set; }

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
            entity.ToTable("Account", tb => tb.HasTrigger("trgCreateUserForAccount"));

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.LoginAttempt).HasColumnName("login_attempt");
            entity.Property(e => e.LoginLast)
                .HasColumnType("datetime")
                .HasColumnName("login_last");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Username).HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Account_Role");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Lớp");

            entity.ToTable("Class");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GradeId).HasColumnName("grade_ id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.TotalStudent).HasColumnName("total_student");
            entity.Property(e => e.TotalStudentSelectedTopics).HasColumnName("total_student_selected_topics");

            entity.HasOne(d => d.Grade).WithMany(p => p.Classes)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Class_Grade");
        });

        modelBuilder.Entity<CurriculumDistribution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Phân phối chương trình");

            entity.ToTable("Curriculum Distribution");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
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
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.OtherTasks).HasColumnName("other_tasks");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Grade).WithMany(p => p.Document1s)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document 1_Grade");

            entity.HasOne(d => d.IsApproveNavigation).WithMany(p => p.Document1s)
                .HasForeignKey(d => d.IsApprove)
                .HasConstraintName("FK_Document 1_IsApprove");

            entity.HasOne(d => d.Subject).WithMany(p => p.Document1s)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document 1_Subject");

            entity.HasOne(d => d.User).WithMany(p => p.Document1s)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phu Luc 1_User");
        });

        modelBuilder.Entity<Document1CurriculumDistribution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Document1_CurriculumDistribution_1");

            entity.ToTable("Document1_CurriculumDistribution");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CurriculumId).HasColumnName("curriculum_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.Slot).HasColumnName("slot");

            entity.HasOne(d => d.Curriculum).WithMany(p => p.Document1CurriculumDistributions)
                .HasForeignKey(d => d.CurriculumId)
                .HasConstraintName("FK_Document1_CurriculumDistribution_Curriculum Distribution");

            entity.HasOne(d => d.Document1).WithMany(p => p.Document1CurriculumDistributions)
                .HasForeignKey(d => d.Document1Id)
                .HasConstraintName("FK_Document1_CurriculumDistribution_Document 11");
        });

        modelBuilder.Entity<Document1PeriodicAssessment>(entity =>
        {
            entity.HasKey(e => new { e.TestingCategoryId, e.FormCategoryId, e.Document1Id }).HasName("PK_Periodic Assessment");

            entity.ToTable("Document1_Periodic Assessment");

            entity.Property(e => e.TestingCategoryId).HasColumnName("testing_category_id");
            entity.Property(e => e.FormCategoryId).HasColumnName("form_category_id");
            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.Document1).WithMany(p => p.Document1PeriodicAssessments)
                .HasForeignKey(d => d.Document1Id)
                .HasConstraintName("FK_Periodic Assessment_Document 1");

            entity.HasOne(d => d.FormCategory).WithMany(p => p.Document1PeriodicAssessments)
                .HasForeignKey(d => d.FormCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document1_Periodic Assessment_Form Category");

            entity.HasOne(d => d.TestingCategory).WithMany(p => p.Document1PeriodicAssessments)
                .HasForeignKey(d => d.TestingCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document1_Periodic Assessment_Testing Category");
        });

        modelBuilder.Entity<Document1SelectedTopic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Document1_SelectedTopics_1");

            entity.ToTable("Document1_SelectedTopics");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.SelectedTopicsId).HasColumnName("selected_topics_id");
            entity.Property(e => e.Slot).HasColumnName("slot");

            entity.HasOne(d => d.Document1).WithMany(p => p.Document1SelectedTopics)
                .HasForeignKey(d => d.Document1Id)
                .HasConstraintName("FK_Document1_SelectedTopics_Document 11");

            entity.HasOne(d => d.SelectedTopics).WithMany(p => p.Document1SelectedTopics)
                .HasForeignKey(d => d.SelectedTopicsId)
                .HasConstraintName("FK_Document1_SelectedTopics_Selected Topics");
        });

        modelBuilder.Entity<Document1SubjectRoom>(entity =>
        {
            entity.ToTable("Document1_Subject Room");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SubjectRoomId).HasColumnName("subject_room_id");

            entity.HasOne(d => d.Document1).WithMany(p => p.Document1SubjectRooms)
                .HasForeignKey(d => d.Document1Id)
                .HasConstraintName("FK_Document1_Subject Room_Document 11");

            entity.HasOne(d => d.SubjectRoom).WithMany(p => p.Document1SubjectRooms)
                .HasForeignKey(d => d.SubjectRoomId)
                .HasConstraintName("FK_Document1_Subject Room_Subject Room");
        });

        modelBuilder.Entity<Document1TeachingEquipment>(entity =>
        {
            entity.ToTable("Document1_TeachingEquipment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Document1Id).HasColumnName("document1_id");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TeachingEquipmentId).HasColumnName("teaching_equipment_id");

            entity.HasOne(d => d.Document1).WithMany(p => p.Document1TeachingEquipments)
                .HasForeignKey(d => d.Document1Id)
                .HasConstraintName("FK_Document1_TeachingEquipment_Document 11");

            entity.HasOne(d => d.TeachingEquipment).WithMany(p => p.Document1TeachingEquipments)
                .HasForeignKey(d => d.TeachingEquipmentId)
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
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.IsApproveNavigation).WithMany(p => p.Document2s)
                .HasForeignKey(d => d.IsApprove)
                .HasConstraintName("FK_Document 2_IsApprove");

            entity.HasOne(d => d.User).WithMany(p => p.Document2s)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Kế hoạch Tổ chức Hoạt Động Giáo Dục_User");
        });

        modelBuilder.Entity<Document2Grade>(entity =>
        {
            entity.ToTable("Document2_Grade");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CollaborateWith).HasColumnName("collaborate_with");
            entity.Property(e => e.Condition).HasColumnName("condition");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Document2Id).HasColumnName("document2_id");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.HostBy).HasColumnName("host_by");
            entity.Property(e => e.Place).HasColumnName("place");
            entity.Property(e => e.Slot).HasColumnName("slot");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.TitleName).HasColumnName("title_name");

            entity.HasOne(d => d.Document2).WithMany(p => p.Document2Grades)
                .HasForeignKey(d => d.Document2Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Document2_Grade_Document 2");

            entity.HasOne(d => d.Grade).WithMany(p => p.Document2Grades)
                .HasForeignKey(d => d.GradeId)
                .HasConstraintName("FK_Document2_Grade_Grade");

            entity.HasOne(d => d.HostByNavigation).WithMany(p => p.Document2Grades)
                .HasForeignKey(d => d.HostBy)
                .HasConstraintName("FK_Document2_Grade_User");
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
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.OtherTasks).HasColumnName("other_tasks");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Document1).WithMany(p => p.Document3s)
                .HasForeignKey(d => d.Document1Id)
                .HasConstraintName("FK_Document 3_Document 1");

            entity.HasOne(d => d.IsApproveNavigation).WithMany(p => p.Document3s)
                .HasForeignKey(d => d.IsApprove)
                .HasConstraintName("FK_Document 3_IsApprove");

            entity.HasOne(d => d.User).WithMany(p => p.Document3s)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document 3_User");
        });

        modelBuilder.Entity<Document3CurriculumDistribution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Document3_CurriculumDistribution_1");

            entity.ToTable("Document3_CurriculumDistribution");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CurriculumId).HasColumnName("curriculum_id");
            entity.Property(e => e.Document3Id).HasColumnName("document3_id");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.Slot).HasColumnName("slot");
            entity.Property(e => e.SubjectRoomId).HasColumnName("subject_room_id");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.Curriculum).WithMany(p => p.Document3CurriculumDistributions)
                .HasForeignKey(d => d.CurriculumId)
                .HasConstraintName("FK_Document3_CurriculumDistribution_Curriculum Distribution");

            entity.HasOne(d => d.Document3).WithMany(p => p.Document3CurriculumDistributions)
                .HasForeignKey(d => d.Document3Id)
                .HasConstraintName("FK_Document3_CurriculumDistribution_Document 3");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Document3CurriculumDistributions)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("FK_Document3_CurriculumDistribution_Teaching Equipment");

            entity.HasOne(d => d.SubjectRoom).WithMany(p => p.Document3CurriculumDistributions)
                .HasForeignKey(d => d.SubjectRoomId)
                .HasConstraintName("FK_Document3_CurriculumDistribution_Subject Room");
        });

        modelBuilder.Entity<Document3SelectedTopic>(entity =>
        {
            entity.ToTable("Document3_SelectedTopics");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Document3Id).HasColumnName("document3_id");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.SelectedTopicsId).HasColumnName("selectedTopics_id");
            entity.Property(e => e.Slot).HasColumnName("slot");
            entity.Property(e => e.SubjectRoomId).HasColumnName("subject_room_id");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.Document3).WithMany(p => p.Document3SelectedTopics)
                .HasForeignKey(d => d.Document3Id)
                .HasConstraintName("FK_Document3_SelectedTopics_Document 3");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Document3SelectedTopics)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("FK_Document3_SelectedTopics_Teaching Equipment");

            entity.HasOne(d => d.SelectedTopics).WithMany(p => p.Document3SelectedTopics)
                .HasForeignKey(d => d.SelectedTopicsId)
                .HasConstraintName("FK_Document3_SelectedTopics_Selected Topics");

            entity.HasOne(d => d.SubjectRoom).WithMany(p => p.Document3SelectedTopics)
                .HasForeignKey(d => d.SubjectRoomId)
                .HasConstraintName("FK_Document3_SelectedTopics_Subject Room");
        });

        modelBuilder.Entity<Document4>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Phu Luc 4");

            entity.ToTable("Document 4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApproveBy).HasColumnName("approve_by");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.IsApprove).HasColumnName("isApprove");
            entity.Property(e => e.LinkFile).HasColumnName("link_file");
            entity.Property(e => e.LinkImage).HasColumnName("link_image");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TeachingPlannerId).HasColumnName("teaching_planner_id");

            entity.HasOne(d => d.IsApproveNavigation).WithMany(p => p.Document4s)
                .HasForeignKey(d => d.IsApprove)
                .HasConstraintName("FK_Document 4_IsApprove");

            entity.HasOne(d => d.TeachingPlanner).WithMany(p => p.Document4s)
                .HasForeignKey(d => d.TeachingPlannerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Document 4_Teaching Planner");
        });

        modelBuilder.Entity<Document5>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Phu Luc 5");

            entity.ToTable("Document 5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Document4Id).HasColumnName("document4_id");
            entity.Property(e => e.LinkFile).HasColumnName("link_file");
            entity.Property(e => e.LinkImage).HasColumnName("link_image");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Slot).HasColumnName("slot");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Document4).WithMany(p => p.Document5s)
                .HasForeignKey(d => d.Document4Id)
                .HasConstraintName("FK_Document 5_Document 4");

            entity.HasOne(d => d.User).WithMany(p => p.Document5s)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Document 5_User");
        });

        modelBuilder.Entity<Evaluate>(entity =>
        {
            entity.ToTable("Evaluate");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Document5Id).HasColumnName("document5_id");
            entity.Property(e => e.Evaluate11).HasColumnName("evaluate_1_1");
            entity.Property(e => e.Evaluate12).HasColumnName("evaluate_1_2");
            entity.Property(e => e.Evaluate13).HasColumnName("evaluate_1_3");
            entity.Property(e => e.Evaluate14).HasColumnName("evaluate_1_4");
            entity.Property(e => e.Evaluate21).HasColumnName("evaluate_2_1");
            entity.Property(e => e.Evaluate22).HasColumnName("evaluate_2_2");
            entity.Property(e => e.Evaluate23).HasColumnName("evaluate_2_3");
            entity.Property(e => e.Evaluate24).HasColumnName("evaluate_2_4");
            entity.Property(e => e.Evaluate31).HasColumnName("evaluate_3_1");
            entity.Property(e => e.Evaluate32).HasColumnName("evaluate_3_2");
            entity.Property(e => e.Evaluate33).HasColumnName("evaluate_3_3");
            entity.Property(e => e.Evaluate34).HasColumnName("evaluate_3_4");

            entity.HasOne(d => d.Document5).WithMany(p => p.Evaluates)
                .HasForeignKey(d => d.Document5Id)
                .HasConstraintName("FK_Evaluate_Document 5");
        });

        modelBuilder.Entity<FormCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Hình thức thi");

            entity.ToTable("Form Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Khối Lớp");

            entity.ToTable("Grade");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<IsApprove>(entity =>
        {
            entity.ToTable("IsApprove");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("name");
        });

        modelBuilder.Entity<LevelOfTrainning>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LevelOfTrainning");

            entity.ToTable("Level Of Trainning");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DocId).HasColumnName("docId");
            entity.Property(e => e.DocType).HasColumnName("doc_type");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.ReceiveBy).HasColumnName("receive_by");
            entity.Property(e => e.SentBy).HasColumnName("sent_by");
            entity.Property(e => e.TitleName).HasColumnName("title_name");

            entity.HasOne(d => d.SentByNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.SentBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notification_User");
        });

        modelBuilder.Entity<ProfessionalStandard>(entity =>
        {
            entity.ToTable("Professional Standards");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Feedback");

            entity.ToTable("Report");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DocId).HasColumnName("doc_id");
            entity.Property(e => e.DocType).HasColumnName("doc_type");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Read).HasColumnName("read");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Report)
                .HasForeignKey<Report>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Report_User");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<S3FileMetadatum>(entity =>
        {
            entity.ToTable("s3_file_metadata");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ExpirationDatetime)
                .HasColumnType("datetime")
                .HasColumnName("expiration_datetime");
            entity.Property(e => e.FileKey).HasColumnName("file_key");
            entity.Property(e => e.PresignedUrl).HasColumnName("presigned_url");
        });

        modelBuilder.Entity<Scorm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Document");

            entity.ToTable("Scorm");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.IsAprrove).HasColumnName("isAprrove");
            entity.Property(e => e.LinkFile).HasColumnName("link_file");
            entity.Property(e => e.LinkImage).HasColumnName("link_image");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TeachingPlannerId).HasColumnName("teaching_planner_id");

            entity.HasOne(d => d.TeachingPlanner).WithMany(p => p.Scorms)
                .HasForeignKey(d => d.TeachingPlannerId)
                .HasConstraintName("FK_Scorm_Teaching Planner");
        });

        modelBuilder.Entity<SelectedTopic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Chuyên đề / Bài Học");

            entity.ToTable("Selected Topics");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
        });

        modelBuilder.Entity<SpecializedDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Tổ chuyên Môn");

            entity.ToTable("Specialized Department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Môn học");

            entity.ToTable("Subject");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.Department).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Subject_Specialized Department");
        });

        modelBuilder.Entity<SubjectRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Phòng Bộ Môn");

            entity.ToTable("Subject Room");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<TeachingEquipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Thiết bị dậy học");

            entity.ToTable("Teaching Equipment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<TeachingPlanner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User - Lớp - Mon");

            entity.ToTable("Teaching Planner");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Class).WithMany(p => p.TeachingPlanners)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teaching Planner_Class");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeachingPlanners)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teaching Planner_Subject");

            entity.HasOne(d => d.User).WithMany(p => p.TeachingPlanners)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teaching Planner_User");
        });

        modelBuilder.Entity<TestingCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Loại Bài kiểm tra");

            entity.ToTable("Testing Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.LevelOfTrainningId).HasColumnName("level_of_trainning_id");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.ProfessionalStandardsId).HasColumnName("professional_standards_id");
            entity.Property(e => e.Signature).HasColumnName("signature");

            entity.HasOne(d => d.Account).WithMany(p => p.Users)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Account");

            entity.HasOne(d => d.Department).WithMany(p => p.Users)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_User_Specialized Department");

            entity.HasOne(d => d.LevelOfTrainning).WithMany(p => p.Users)
                .HasForeignKey(d => d.LevelOfTrainningId)
                .HasConstraintName("FK_User_Level Of Trainning");

            entity.HasOne(d => d.ProfessionalStandards).WithMany(p => p.Users)
                .HasForeignKey(d => d.ProfessionalStandardsId)
                .HasConstraintName("FK_User_Professional Standards");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
