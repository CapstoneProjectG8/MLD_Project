using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project_MLD.DTO;
using Project_MLD.Models;

namespace Project_MLD.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //Account
            CreateMap<Account, AccountDTO>()
                .ReverseMap();
            CreateMap<AccountDTO, Account>()
                .ForMember(x => x.Users, y => y.Ignore())
                .ForMember(x => x.Role, y => y.Ignore())
                .ReverseMap();

            //Noti
            CreateMap<Notification, NotificationDTO>()
                .ForMember(x => x.SentByName, y => y.MapFrom(src => src.SentByNavigation.FirstName + " " + src.SentByNavigation.LastName))
                .ReverseMap();
            CreateMap<NotificationDTO, Notification>()
                .ForMember(x => x.SentByNavigation, y => y.Ignore())
                .ReverseMap();

            //Report
            CreateMap<Report, ReportDTO>()
                .ForMember(x => x.UserName, y => y.MapFrom(src => src.IdNavigation.FirstName + " " + src.IdNavigation.LastName))
                .ReverseMap();
            CreateMap<ReportDTO, Report>()
                .ForMember(x => x.IdNavigation, y => y.Ignore())
                .ReverseMap();

            //User
            CreateMap<User, UserDTO>()
                .ReverseMap();
            CreateMap<UserDTO, User>()
                .ForMember(x => x.Report, y => y.Ignore())
                .ForMember(x => x.Account, y => y.Ignore())
                .ForMember(x => x.ProfessionalStandards, y => y.Ignore())
                .ForMember(x => x.LevelOfTrainning, y => y.Ignore())
                .ForMember(x => x.Document1s, y => y.Ignore())
                .ForMember(x => x.Document2s, y => y.Ignore())
                .ForMember(x => x.Document3s, y => y.Ignore())
                .ForMember(x => x.TeachingPlanners, y => y.Ignore())
                .ForMember(x => x.Document5s, y => y.Ignore())
                .ForMember(x => x.Document2Grades, y => y.Ignore())
                .ReverseMap();

            //Document1
            CreateMap<Document1, Document1DTO>()
                .ForMember(x => x.SubjectName, y => y.MapFrom(src => src.Subject.Name))
                .ForMember(x => x.GradeName, y => y.MapFrom(src => src.Grade.Name))
                .ForMember(dest => dest.UserFullName, x => x.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ReverseMap();
            CreateMap<Document1DTO, Document1>()
                .ForMember(dest => dest.Subject, opt => opt.Ignore())
                .ForMember(dest => dest.Grade, opt => opt.Ignore())// Ignore complex Subject property
                .ForMember(dest => dest.User, opt => opt.Ignore()) // Ignore complex User property
                .ReverseMap();

            //Document1CurriculumDistribution
            CreateMap<Document1CurriculumDistribution, Document1CurriculumDistributionDTO>()
               .ForMember(x => x.CurriculumName, y => y.MapFrom(src => src.Curriculum.Name))
               .ReverseMap();
            CreateMap<Document1CurriculumDistributionDTO, Document1CurriculumDistribution>()
               .ForMember(x => x.Curriculum, y => y.Ignore())
               .ForMember(x => x.Document1, y => y.Ignore())
               .ReverseMap();

            //Document1TeachingEquipment
            CreateMap<Document1TeachingEquipment, Document1TeachingEquipmentsDTO>()
                .ForMember(x => x.TeachingEquipmentName, y => y.MapFrom(src => src.TeachingEquipment.Name))
                .ReverseMap();
            CreateMap<Document1TeachingEquipmentsDTO, Document1TeachingEquipment>()
                .ForMember(x => x.TeachingEquipment, y => y.Ignore())
                .ForMember(x => x.Document1, y => y.Ignore())
                .ReverseMap();

            //Document1SelectedTopic
            CreateMap<Document1SelectedTopic, Document1SelectedTopicsDTO>()
                .ForMember(x => x.SelectedTopicsName, y => y.MapFrom(src => src.SelectedTopics.Name))
                .ReverseMap();
            CreateMap<Document1SelectedTopicsDTO, Document1SelectedTopic>()
                .ForMember(x => x.SelectedTopics, y => y.Ignore())
                .ForMember(x => x.Document1, y => y.Ignore())
                .ReverseMap();

            //Document1SubjectRoom
            CreateMap<Document1SubjectRoom, Document1SubjectRoomDTO>()
                .ForMember(x => x.SubjectRoomName, y => y.MapFrom(src => src.SubjectRoom.Name))
                .ReverseMap();
            CreateMap<Document1SubjectRoomDTO, Document1SubjectRoom>()
                .ForMember(x => x.SubjectRoom, y => y.Ignore())
                .ForMember(x => x.Document1, y => y.Ignore())
                .ReverseMap();

            //Document1PeriodicAssessment
            CreateMap<Document1PeriodicAssessment, Document1PeriodicAssessmentDTO>()
                .ForMember(x => x.FormCategoryName, y => y.MapFrom(src => src.FormCategory.Name))
                .ForMember(x => x.TestingCategoryName, y => y.MapFrom(src => src.TestingCategory.Name))
                .ReverseMap();
            CreateMap<Document1PeriodicAssessmentDTO, Document1PeriodicAssessment>()
                .ForMember(x => x.FormCategory, y => y.Ignore())
                .ForMember(x => x.TestingCategory, y => y.Ignore())
                .ForMember(x => x.Document1, y => y.Ignore())
                .ReverseMap();

            //Document2
            CreateMap<Document2, Document2DTO>()
                .ForMember(x => x.UserFullName, y => y.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ReverseMap();
            CreateMap<Document2DTO, Document2>()
                .ForMember(dest => dest.Document2Grades, opt => opt.Ignore())
                .ForMember(dest => dest.IsApproveNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())// Ignore complex User property
                .ReverseMap();

            //Document2Grade
            CreateMap<Document2Grade, Document2GradeDTO>()
                .ForMember(x => x.GradeName, y => y.MapFrom(src => src.Grade.Name))
                .ForMember(x => x.HostByName, y => y.MapFrom(src => src.HostByNavigation.FirstName + " " + src.HostByNavigation.LastName))
                .ReverseMap();
            CreateMap<Document2GradeDTO, Document2Grade>()
                .ForMember(x => x.Grade, y => y.Ignore())
                .ForMember(x => x.HostByNavigation, y => y.Ignore())
                .ForMember(x => x.Document2, y => y.Ignore())
                .ReverseMap();

            //Document3
            CreateMap<Document3, Document3DTO>()
                .ForMember(x => x.Document1Name, y => y.MapFrom(src => src.Document1.Name))
                .ForMember(x => x.UserFullName, y => y.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ReverseMap();
            CreateMap<Document3DTO, Document3>()
                .ForMember(dest => dest.User, opt => opt.Ignore()) // Ignore complex User property
                .ForMember(dest => dest.Document1, opt => opt.Ignore())
                .ReverseMap();

            //Document3CurriculumDistribution
            CreateMap<Document3CurriculumDistribution, Document3CurriculumDistributionDTO>()
                .ForMember(x => x.CurriculumName, y => y.MapFrom(src => src.Curriculum.Name))
                .ForMember(x => x.EquipmentName, y => y.MapFrom(src => src.Equipment.Name))
                .ForMember(x => x.SubjectRoomName, y => y.MapFrom(src => src.SubjectRoom.Name))
                .ReverseMap();
            CreateMap<Document3CurriculumDistributionDTO, Document3CurriculumDistribution>()
                .ForMember(x => x.Curriculum, y => y.Ignore())
                .ForMember(x => x.Equipment, y => y.Ignore())
                .ForMember(x => x.Document3, y => y.Ignore())
                .ForMember(x => x.SubjectRoom, y => y.Ignore())
                .ReverseMap();

            //Document3SelectedTopic
            CreateMap<Document3SelectedTopic, Document3SelectedTopicDTO>()
                .ForMember(x => x.SelectedTopicsName, y => y.MapFrom(src => src.SelectedTopics.Name))
                .ForMember(x => x.EquipmentName, y => y.MapFrom(src => src.Equipment.Name))
                .ForMember(x => x.SubjectRoomName, y => y.MapFrom(src => src.SubjectRoom.Name))
                .ReverseMap();
            CreateMap<Document3SelectedTopicDTO, Document3SelectedTopic>()
                .ForMember(x => x.SelectedTopics, y => y.Ignore())
                .ForMember(x => x.SubjectRoom, y => y.Ignore())
                .ForMember(x => x.Equipment, y => y.Ignore())
                .ForMember(x => x.Document3, y => y.Ignore())
                .ReverseMap();

            CreateMap<Document4, Document4DTO>()
                .ForMember(x => x.UserName, y => y.MapFrom(src => src.TeachingPlanner.User.FirstName + " " + src.TeachingPlanner.User.LastName))
                .ForMember(x => x.ClassName, y => y.MapFrom(src => src.TeachingPlanner.Class.Name))
                .ForMember(x => x.SubjectName, y => y.MapFrom(src => src.TeachingPlanner.Subject.Name))
                .ReverseMap();

            CreateMap<Document4DTO, Document4>()
                .ForMember(dest => dest.TeachingPlanner, opt => opt.Ignore())
                .ForMember(dest => dest.Document5s, opt => opt.Ignore())
                .ForMember(dest => dest.IsApprove, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<TeachingPlanner, TeachingPlannerDTO>()
                .ReverseMap();

            CreateMap<Document5, Document5DTO>()
                .ForMember(x => x.UserFullName, y => y.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ReverseMap();
            CreateMap<Document5DTO, Document5>()
                .ForMember(dest => dest.Document4, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ReverseMap();

            //class
            CreateMap<Class, ClassDTO>()
                .ForMember(x => x.GradeName, y => y.MapFrom(src => src.Grade.Name))
                .ReverseMap();
            CreateMap<ClassDTO, Class>()
                .ForMember(dest => dest.Grade, opt => opt.Ignore())
                .ForMember(dest => dest.TeachingPlanners, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Evaluate, EvaluateDTO>()
                .ReverseMap();
            CreateMap<EvaluateDTO, Evaluate>()
                .ForMember(dest => dest.Document5, opt => opt.Ignore())
                .ReverseMap();

            //CurriculumDistribution
            CreateMap<CurriculumDistribution, CurriculumDistributionDTO>()
                .ReverseMap();
            CreateMap<CurriculumDistributionDTO, CurriculumDistribution>()
                .ForMember(dest => dest.Document1CurriculumDistributions, opt => opt.Ignore())
                .ForMember(dest => dest.Document3CurriculumDistributions, opt => opt.Ignore())
                .ReverseMap();

            //TestingCategory && FormCategory
            CreateMap<TestingCategory, TestingCategoryDTO>()
                .ReverseMap();
            CreateMap<TestingCategoryDTO, TestingCategory>()
                .ForMember(dest => dest.Document1PeriodicAssessments, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<FormCategory, FormCategoryDTO>()
                .ReverseMap();
            CreateMap<FormCategoryDTO, FormCategory>()
                .ForMember(dest => dest.Document1PeriodicAssessments, opt => opt.Ignore())
                .ReverseMap();

            //teaching quipment
            CreateMap<TeachingEquipment, TeachingEquipmentDTO>()
               .ReverseMap();
            CreateMap<TeachingEquipmentDTO, TeachingEquipment>()
                .ForMember(dest => dest.Document1TeachingEquipments, opt => opt.Ignore())
                .ForMember(dest => dest.Document3CurriculumDistributions, opt => opt.Ignore())
                .ForMember(dest => dest.Document3SelectedTopics, opt => opt.Ignore())
                .ReverseMap();

            //subject 
            CreateMap<Subject, SubjectDTO>()
               .ReverseMap();
            CreateMap<SubjectDTO, Subject>()
                .ForMember(dest => dest.Department, opt => opt.Ignore())
                .ForMember(dest => dest.Document1s, opt => opt.Ignore())
                .ForMember(dest => dest.TeachingPlanners, opt => opt.Ignore())
                .ReverseMap();

            //grade
            CreateMap<Grade, GradeDTO>()
               .ReverseMap();
            CreateMap<GradeDTO, Grade>()
                .ForMember(dest => dest.Classes, opt => opt.Ignore())
                .ForMember(dest => dest.Document1s, opt => opt.Ignore())
                .ForMember(dest => dest.Document2Grades, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<SpecializedDepartment, SpecializedDepartmentDTO>()
               .ReverseMap();
            CreateMap<SpecializedDepartmentDTO, SpecializedDepartment>()
                .ForMember(dest => dest.Subjects, opt => opt.Ignore())
                .ForMember(dest => dest.Users, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<SubjectRoom, SubjectRoomDTO>()
              .ReverseMap();
            CreateMap<SubjectRoomDTO, SubjectRoom>()
                .ForMember(dest => dest.Document1SubjectRooms, opt => opt.Ignore())
                .ForMember(dest => dest.Document3CurriculumDistributions, opt => opt.Ignore())
                .ForMember(dest => dest.Document3SelectedTopics, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<SelectedTopic, SelectedTopicDTO>()
              .ReverseMap();
            CreateMap<SelectedTopicDTO, SelectedTopic>()
                .ForMember(dest => dest.Document1SelectedTopics, opt => opt.Ignore())
                .ForMember(dest => dest.Document3SelectedTopics, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<LevelOfTrainning, LevelOfTrainningDTO>()
             .ReverseMap();
            CreateMap<LevelOfTrainningDTO, LevelOfTrainning>()
                .ForMember(dest => dest.Users, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<ProfessionalStandard, ProfessionalStandardDTO>()
             .ReverseMap();
            CreateMap<ProfessionalStandardDTO, ProfessionalStandard>()
                .ForMember(dest => dest.Users, opt => opt.Ignore())
                .ReverseMap();

        }
    }
    }

