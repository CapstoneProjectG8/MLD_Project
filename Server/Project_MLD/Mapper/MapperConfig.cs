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
                .ForMember(x => x.RoleName, y => y.MapFrom(src => src.Role.RoleName))
                .ForMember(x => x.FullName, y => y.MapFrom(src => src.Users.FirstOrDefault().FullName))
                .ReverseMap();
        }
    }
}
