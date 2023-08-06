using AutoMapper;
using Zdenac_API.Models.DTOs;
using Zdenac_API.Repositories.Interfaces;
using Zdenac_API.Services.Interfaces;

namespace Zdenac_API.Services
{
    public class ChildService:IChildService
    {
        private readonly IChildRepository _childRepository;
        private readonly IMapper _mapper;

        public ChildService(IChildRepository childRepository, IMapper mapper)
        {
            _childRepository = childRepository;
            _mapper = mapper;
        }

        public async Task AddChild(ChildDTO dto)
        {
            var child = _mapper.Map<Child>(dto);
            await _childRepository.AddChild(child);
        }

        public async Task DeleteChild(int childId)
        {
            var child = await _childRepository.GetChildById(childId);

            if (child != null)
            {
                await _childRepository.DeleteChild(child.Id);
            }

            
        }

        public async Task UpdateChild(int childId, ChildDTO dto)
        {
            var child = await _childRepository.GetChildById(childId);

            if (child != null && dto != null)
            {
                _mapper.Map(dto, child);
                await _childRepository.UpdateChild(child);
            }
            
        }

        public async Task<IEnumerable<Child>> GetAllChildren()     
            => await _childRepository.GetAllChildren();
        

        public async Task<Child> GetChildById(int childId)
            => await _childRepository.GetChildById(childId);
        

    }
}
