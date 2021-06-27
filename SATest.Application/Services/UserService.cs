using AutoMapper;
using SATest.Entities.Entities;
using SATest.Infrastructure.Repositories;
using SATest.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SATest.Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<int> CreateUser(UserForCreationDto userDto);
        Task<UserDto> GetUserById(int id);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ??
                throw new ArgumentNullException(nameof(userRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var userFromRepo = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(userFromRepo);
        }

        public async Task<int> CreateUser(UserForCreationDto userCreationDto)
        {
            var userEntity = _mapper.Map<User>(userCreationDto);
            var newUserId = await _userRepository.Add(userEntity);
            return newUserId;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var userFromRepo = await _userRepository.Get(id);
            return _mapper.Map<UserDto>(userFromRepo);
        }
    }
}
