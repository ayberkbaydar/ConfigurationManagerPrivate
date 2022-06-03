using ConfigurationManager.Core.DTOs;
using ConfigurationManager.Core.Models;

namespace ConfigurationManager.Core.Services
{
    public interface IUserService : IGenericService<User>
    {
        Task<CustomResponseDto<List<UserDto>>> GetUsers();
    }
}
