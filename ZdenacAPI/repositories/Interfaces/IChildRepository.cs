using Zdenac_API.Models.DTOs;

namespace Zdenac_API.Repositories.Interfaces
{
    public interface IChildRepository
    {
        Task<List<Child>> GetAllChildren();
        Task<Child> GetChildById(int childId);
        Task DeleteChild(int childId);
        Task<Child> AddChild(Child child);
        Task UpdateChild(Child child, ChildDTO dto);
    }
}
