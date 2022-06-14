using AutoMapper;
using ConfigurationManager.Core.DTOs;
using ConfigurationManager.Core.Models;
using ConfigurationManager.Core.Repositories;
using ConfigurationManager.Core.Services;
using ConfigurationManager.Core.UnitOfWorks;
using ConfigurationManager.Repository.Providers.MongoDB;
using Microsoft.Extensions.Options;

namespace ConfigurationManager.Service.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository) : base(repository, unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<UserDto>>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            var usersDto = _mapper.Map<List<UserDto>>(users);
            return CustomResponseDto<List<UserDto>>.Success(200, usersDto);
        }
    }
}
