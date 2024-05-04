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
            CreateMap<Account, AccountDTO>()
                .ReverseMap();
            CreateMap<AccountDTO, Account>()
                .ForMember(x => x.Users, y => y.Ignore())
                .ForMember(x => x.Role, y => y.Ignore())
                .ReverseMap();
            CreateMap<Notification, NotificationDTO>()
                .ForMember(x => x.SentByName, y => y.MapFrom(src => src.SentByNavigation.FirstName + " " + src.SentByNavigation.LastName))
                .ReverseMap();
            CreateMap<NotificationDTO, Notification>()
                .ForMember(x => x.SentByNavigation, y => y.Ignore())
                .ReverseMap();
            CreateMap<Report, ReportDTO>()
                .ForMember(x => x.UserName, y => y.MapFrom(src => src.IdNavigation.FirstName + " " + src.IdNavigation.LastName))
                .ReverseMap();
            CreateMap<ReportDTO, Report>()
                .ForMember(x => x.IdNavigation, y => y.Ignore())
                .ReverseMap();

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

            CreateMap<Document1, Document1DTO>()
                .ForMember(x => x.SubjectId, y => y.MapFrom(src => src.SubjectId))
                .ForMember(x => x.GradeId, y => y.MapFrom(src => src.GradeId))
                .ForMember(x => x.UserId, y => y.MapFrom(src => src.UserId))
                .ForMember(x => x.SubjectName, y => y.MapFrom(src => src.Subject.Name))
                .ForMember(x => x.GradeName, y => y.MapFrom(src => src.Grade.Name))
                .ForMember(x => x.UserFullName, y => y.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ReverseMap();
            CreateMap<Document1DTO, Document1>()
                .ForMember(dest => dest.Subject, opt => opt.Ignore())
                .ForMember(dest => dest.Grade, opt => opt.Ignore())// Ignore complex Subject property
                .ForMember(dest => dest.User, opt => opt.Ignore()) // Ignore complex User property
                .ReverseMap();


            CreateMap<Document1CurriculumDistribution, Document1CurriculumDistributionDTO>()
               .ForMember(x => x.CurriculumId, y => y.MapFrom(src => src.Curriculum.Id))
               .ForMember(x => x.Document1Id, y => y.MapFrom(src => src.Document1.Id))
               .ForMember(x => x.CurriculumName, y => y.MapFrom(src => src.Curriculum.Name))
               .ReverseMap();
            CreateMap<Document1TeachingEquipment, Document1TeachingEquipmentsDTO>()
                .ForMember(x => x.TeachingEquipmentId, y => y.MapFrom(src => src.TeachingEquipment.Id))
                .ForMember(x => x.Document1Id, y => y.MapFrom(src => src.Document1.Id))
                .ForMember(x => x.TeachingEquipmentName, y => y.MapFrom(src => src.TeachingEquipment.Name))
                .ReverseMap();
            CreateMap<Document1SelectedTopic, Document1SelectedTopicsDTO>()
                .ForMember(x => x.SelectedTopicsName, y => y.MapFrom(src => src.SelectedTopics.Name))
                .ForMember(x => x.Document1Id, y => y.MapFrom(src => src.Document1.Id))
                .ForMember(x => x.SelectedTopicsId, y => y.MapFrom(src => src.SelectedTopics.Id))
                .ReverseMap();
            CreateMap<Document1SubjectRoom, Document1SubjectRoomDTO>()
                .ForMember(x => x.SubjectRoomId, y => y.MapFrom(src => src.SubjectRoom.Id))
                .ForMember(x => x.Document1Id, y => y.MapFrom(src => src.Document1.Id))
                .ForMember(x => x.SubjectRoomName, y => y.MapFrom(src => src.SubjectRoom.Name))
                .ReverseMap();
            CreateMap<Document1PeriodicAssessment, Document1PeriodicAssessmentDTO>()
                .ForMember(x => x.FormCategoryId, y => y.MapFrom(src => src.FormCategory.Id))
                .ForMember(x => x.FormCategoryName, y => y.MapFrom(src => src.FormCategory.Name))
                .ForMember(x => x.TestingCategoryId, y => y.MapFrom(src => src.TestingCategory.Id))
                .ForMember(x => x.TestingCategoryName, y => y.MapFrom(src => src.TestingCategory.Name))
                .ReverseMap();
            CreateMap<Document1PeriodicAssessmentDTO, Document1PeriodicAssessment>()
                .ForMember(x => x.FormCategory, y => y.Ignore())
                .ForMember(x => x.TestingCategory, y => y.Ignore())
                .ReverseMap();

            CreateMap<Document2, Document2DTO>()
                .ForMember(x => x.UserFullName, y => y.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ReverseMap();
            CreateMap<Document2DTO, Document2>()
                .ForMember(dest => dest.User, opt => opt.Ignore()) // Ignore complex User property
                .ReverseMap();

            CreateMap<Document2Grade, Document2GradeDTO>()
                .ForMember(x => x.GradeName, y => y.MapFrom(src => src.Grade.Name))
                .ForMember(x => x.HostByName, y => y.MapFrom(src => src.HostByNavigation.FirstName + " " + src.HostByNavigation.LastName))
                .ReverseMap();
            CreateMap<Document2GradeDTO, Document2Grade>()
                .ForMember(x => x.Grade, y => y.Ignore())
                .ForMember(x => x.HostByNavigation, y => y.Ignore())
                .ReverseMap();

            CreateMap<Document3, Document3DTO>()
                .ForMember(x => x.Document1Name, y => y.MapFrom(src => src.Document1.Name))
                .ForMember(x => x.UserFullName, y => y.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ReverseMap();
            CreateMap<Document3DTO, Document3>()
                .ForMember(dest => dest.User, opt => opt.Ignore()) // Ignore complex User property
                .ForMember(dest => dest.Document1, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Document3CurriculumDistribution, Document3CurriculumDistributionDTO>()
                .ForMember(x => x.CurriculumId, y => y.MapFrom(src => src.Curriculum.Id))
                .ForMember(x => x.Document3Id, y => y.MapFrom(src => src.Document3.Id))
                .ForMember(x => x.EquipmentId, y => y.MapFrom(src => src.Equipment.Id))
                .ForMember(x => x.CurriculumName, y => y.MapFrom(src => src.Curriculum.Name))
                .ForMember(x => x.EquipmentName, y => y.MapFrom(src => src.Equipment.Name))
                .ReverseMap();
            CreateMap<Document3SelectedTopic, Document3SelectedTopicDTO>()
                .ForMember(x => x.SelectedTopicsId, y => y.MapFrom(src => src.SelectedTopics.Id))
                .ForMember(x => x.Document3Id, y => y.MapFrom(src => src.Document3.Id))
                .ForMember(x => x.EquipmentId, y => y.MapFrom(src => src.Equipment.Id))
                .ForMember(x => x.SelectedTopicsName, y => y.MapFrom(src => src.SelectedTopics.Name))
                .ForMember(x => x.EquipmentName, y => y.MapFrom(src => src.Equipment.Name))
                .ReverseMap();

            CreateMap<Document4, Document4DTO>()
                .ForMember(x => x.TeachingPlannerId, y => y.MapFrom(src => src.TeachingPlannerId))
                .ReverseMap();
            CreateMap<Document4DTO, Document4>()
                .ForMember(dest => dest.TeachingPlanner, opt => opt.Ignore())
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

            CreateMap<Class, ClassDTO>()
                .ForMember(x => x.GradeName, y => y.MapFrom(src => src.Grade.Name))
                .ReverseMap();
            CreateMap<ClassDTO, Class>()
                .ForMember(dest => dest.Grade, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Evaluate, EvaluateDTO>()
                .ReverseMap();
            CreateMap<EvaluateDTO, Evaluate>()
                .ForMember(dest => dest.Document5, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
