namespace Zdenac_API
{
    using AutoMapper;
    using Zdenac_API.Models.DTOs;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ChildDTO, Child>(); 
        }
    }
}
