using AutoMapper;
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
                .ReverseMap();

            CreateMap<User, UserDTO>()
                .ForMember(x => x.AccountId, y => y.MapFrom(src => src.AccountId))
                .ForMember(x => x.FullName, y => y.MapFrom(src => src.LastName + " " + src.FirstName))
                .ForMember(x => x.LevelOfTrainningId, y => y.MapFrom(src => src.LevelOfTrainningId))
                .ForMember(x => x.SpecializedDepartmentId, y => y.MapFrom(src => src.SpecializedDepartmentId))
                .ForMember(x => x.ProfessionalStandardsId, y => y.MapFrom(src => src.ProfessionalStandardsId))
                .ForMember(x => x.CreatedDate, y => y.MapFrom(x => DateOnly.FromDateTime(DateTime.Now)))
                .ForMember(x => x.CreatedBy, y => y.MapFrom(x => "ADMIN"))
                .ReverseMap();

            CreateMap<Document1, Document1DTO>()
                .ForMember(x => x.ApproveByName, y => y.MapFrom(src => src.User.FullName))
                .ReverseMap();
            CreateMap<Document2, Document2DTO>()
                .ReverseMap();
            CreateMap<Document3, Document3DTO>()
                .ReverseMap();
            CreateMap<Document4, Document4DTO>()
                .ReverseMap();
            CreateMap<Document5, Document5DTO>()
                .ReverseMap();
        }
    }
}
