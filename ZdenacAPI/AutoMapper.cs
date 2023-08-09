using AutoMapper;
using Zdenac_API.Models.DTOs;

namespace Zdenac_API
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<ChildDTO, Child>();
        }
    }
}
