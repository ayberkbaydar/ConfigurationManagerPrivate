using AutoMapper;
using ConfigurationManager.Core.DTOs;
using ConfigurationManager.Core.Models;

namespace ConfigurationManager.Service.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
