using AutoMapper;
using Zdenac_API.Models.DTOs;
using Zdenac_API.Repositories.Interfaces;

namespace Zdenac_API.Services
{
    public class ChildService
    {
        private readonly IChildRepository _childRepository;
        private readonly IMapper _mapper;

        public ChildService(IChildRepository childRepository, IMapper mapper)
        {
            _childRepository = childRepository;
            _mapper = mapper;
        }

        public async Task AddChildAsync(ChildDTO dto)
        {
            var child = _mapper.Map<Child>(dto);
            await _childRepository.AddChild(child);
        }
    }
}
