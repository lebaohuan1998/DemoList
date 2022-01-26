using DemoList.Models;

namespace DemoList.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken();
    }
}
