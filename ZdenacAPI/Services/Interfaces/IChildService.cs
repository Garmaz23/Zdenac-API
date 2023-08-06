using Zdenac_API.Models.DTOs;

namespace Zdenac_API.Services.Interfaces
{
    public interface IChildService
    {
        Task AddChild(ChildDTO dto);
        Task DeleteChild(int childId);
        Task UpdateChild(int childId, ChildDTO dto);
        Task<IEnumerable<Child>> GetAllChildren();
        Task<Child> GetChildById(int childId);


    }
}
