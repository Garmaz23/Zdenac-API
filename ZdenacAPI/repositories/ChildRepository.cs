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

        public async Task AddChild(Child child)
        {
            
                if (child != null)
                {
                    _dbContext.Children.Add(child);
                    await _dbContext.SaveChangesAsync();
                }

        }

        public async Task DeleteChild(int childId)
        {
            var childForDelete = GetChildById(childId);

            if (childForDelete != null)
            {
                _dbContext.Children.Remove(await childForDelete);
                await _dbContext.SaveChangesAsync();

            }

        }

        public async Task<List<Child>> GetAllChildren()
            => await _dbContext.Set<Child>().ToListAsync();


        public async Task<Child> GetChildById(int childId)
            => await _dbContext.Set<Child>().FirstOrDefaultAsync(x => x.Id == childId);

        public async Task UpdateChild(Child child)
        {
            if (child != null)
            {
                
                _dbContext.Entry(child).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
