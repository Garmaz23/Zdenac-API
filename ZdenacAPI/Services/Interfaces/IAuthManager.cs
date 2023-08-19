using Zdenac_API.Models.DTOs;

namespace Zdenac_API.Services.Interfaces
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken();


    }
}
