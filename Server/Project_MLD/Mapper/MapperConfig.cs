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
                .ForMember(x => x.AccountId, y => y.MapFrom(src => src.AccountId))
                .ForMember(x => x.RoleId, y => y.MapFrom(src => src.RoleId))
                .ForMember(x => x.CreatedDate, y => y.MapFrom(x => DateOnly.FromDateTime(DateTime.Now)))
                .ForMember(x => x.CreatedBy, y => y.MapFrom(x => "ADMIN"))
                .ForMember(x => x.LoginAttempt, y => y.MapFrom(src => src.LoginAttempt))
                .ForMember(x => x.LoginLast, y => y.MapFrom(src => src.LoginLast))
                .ReverseMap();

            CreateMap<Notification, NotificationDTO>()
                .ForMember(x => x.SentByName, y => y.MapFrom(src => src.SentByNavigation.Id))
                .ForMember(x => x.ReceiveByName, y => y.MapFrom(src => src.SentByNavigation.Id))
                .ReverseMap();
            CreateMap<NotificationDTO, Notification>()
                .ForMember(x => x.SentByNavigation, y => y.Ignore())
                .ReverseMap();

            CreateMap<User, UserDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(src => src.Id))
                .ForMember(x => x.AccountId, y => y.MapFrom(src => src.AccountId))
                .ForMember(x => x.FullName, y => y.MapFrom(src => src.LastName + " " + src.FirstName))
                .ForMember(x => x.LevelOfTrainningId, y => y.MapFrom(src => src.LevelOfTrainningId))
                .ForMember(x => x.SpecializedDepartmentId, y => y.MapFrom(src => src.SpecializedDepartmentId))
                .ForMember(x => x.ProfessionalStandardsId, y => y.MapFrom(src => src.ProfessionalStandardsId))
                .ForMember(x => x.CreatedDate, y => y.MapFrom(x => DateOnly.FromDateTime(DateTime.Now)))
                .ForMember(x => x.CreatedBy, y => y.MapFrom(x => "ADMIN"))
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
            CreateMap<PeriodicAssessment, PeriodicAssessmentDTO>()
                .ForMember(x => x.FormCategoryId, y => y.MapFrom(src => src.FormCategory.Id))
                .ForMember(x => x.FormCategoryName, y => y.MapFrom(src => src.FormCategory.Name))
                .ForMember(x => x.TestingCategoryId, y => y.MapFrom(src => src.TestingCategory.Id))
                .ForMember(x => x.TestingCategoryName, y => y.MapFrom(src => src.TestingCategory.Name))
                .ReverseMap();
            CreateMap<PeriodicAssessmentDTO, PeriodicAssessment>()
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
                .ForMember(x => x.HostByName, y => y.MapFrom(src => src.HostByNavigation.FullName))
                .ReverseMap();
            CreateMap<Document2GradeDTO, Document2Grade>()
                .ForMember(x => x.Grade, y => y.Ignore())
                .ForMember(x => x.HostByNavigation, y => y.Ignore())
                .ReverseMap();

            CreateMap<Document3, Document3DTO>()
                //.ForMember(x => x.Id, y => y.MapFrom(src => src.Id))
                //.ForMember(x => x.UserId, y => y.MapFrom(src => src.UserId))
                //.ForMember(x => x.Document1Id, y => y.MapFrom(src => src.Document1Id))
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
                .ForMember(x => x.GradeId, y => y.MapFrom(src => src.Grade.Id))
                .ForMember(x => x.GradeName, y => y.MapFrom(src => src.Grade.Name))
                .ReverseMap();

            CreateMap<Evaluate, EvaluateDTO>()
                .ReverseMap();
            CreateMap<EvaluateDTO, Evaluate>()
                .ForMember(dest => dest.Document5, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
