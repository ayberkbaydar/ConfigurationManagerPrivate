using AutoMapper;
using ConfigurationManager.Core.DTOs;
using ConfigurationManager.Core.Models;
using ConfigurationManager.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationManager.API.Controllers
{
    public class UsersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IGenericService<User> _service;
        public UsersController(IGenericService<User> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //Get api/users
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _service.GetAllAsync();
            var usersDto = _mapper.Map<List<UserDto>>(users.ToList());
            return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200, usersDto));
        }

        //Get api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            var userDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, userDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            var user = await _service.AddAsync(_mapper.Map<User>(userDto));
            var usersDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(201, usersDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            await _service.UpdateAsync(_mapper.Map<User>(userDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        //DELETE api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _service.GetByIdAsync(id);

            if (user==null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404,"This id could not be found."));
            }
            await _service.RemoveAsync(user);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
