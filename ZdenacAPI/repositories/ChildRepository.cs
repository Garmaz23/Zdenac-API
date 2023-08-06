using AutoMapper;
using Zdenac_API.Models;
using Zdenac_API.Models.DTOs;
using Zdenac_API.Repositories.Interfaces;

namespace Zdenac_API.Repositories
{
    public class ChildRepository : IChildRepository
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        public ChildRepository(DataContext dbContex, IMapper mapper)
        {
            _dbContext = dbContex;
            _mapper = mapper;
        }

        public async Task<Child> AddChild(Child child)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteChild(int childId)
        {
            var childForDelete =  GetChildById(childId);

            if (childForDelete! == null)
            {
                _dbContext.Children.Remove(await childForDelete);
                await _dbContext.SaveChangesAsync();

            }

        }

        public async Task<List<Child>> GetAllChildren()
            => await _dbContext.Set<Child>().ToListAsync();


        public async Task<Child> GetChildById(int childId)
            => await _dbContext.Set<Child>().FirstOrDefaultAsync(x => x.Id == childId);

        public async Task UpdateChild(Child child, ChildDTO dto)
        { 
            if (child != null)
            {
                _mapper.Map(dto, child); 
                _dbContext.Entry(child).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
