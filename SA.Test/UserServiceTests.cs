using AutoMapper;
using NSubstitute;
using SATest.Application.Services;
using SATest.Entities.Entities;
using SATest.Infrastructure.Repositories;
using SATest.Models.DTO;
using System.Threading.Tasks;
using Xunit;

namespace SA.Test
{
    public class UserServiceTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserServiceTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _mapper = Substitute.For<IMapper>();
            _userService = new UserService(_userRepository, _mapper);
        }

        [Fact]
        public async void CreateUser_Should_Return_New_Id()
        {
            //Arrange
            _userRepository.Add(Arg.Any<User>()).Returns(Task.FromResult(1));

            //Act
            var result = await _userService.CreateUser(new UserForCreationDto() { FirstName = "a", LastName = "b", Email = "abcd@efg.com", IsMale = true, Status = true });

            //Assert
            Assert.Equal(1, result);
        }
    }
}
