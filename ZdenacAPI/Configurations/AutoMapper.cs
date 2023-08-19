using AutoMapper;
using Zdenac_API.Models.DTOs;

namespace Zdenac_API.Configurations
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ChildDTO, Child>().ReverseMap();
            CreateMap<ApiUser, UserDTO>().ReverseMap();
        }
    }
}
