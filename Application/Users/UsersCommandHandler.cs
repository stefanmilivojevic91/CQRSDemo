using System;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Users.Commands;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Users
{
    public class UsersCommandHandler : IUsersCommandHandler
    {
        private readonly IUserRepository _userRepository;

        public UsersCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> HandleAsync(AddUserCommand command)
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = command.FirstName,
                LastName = command.LastName
            };

            _userRepository.AddUser(user);

            var result = await _userRepository.SaveAsync();

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<UserDto> HandleAsync(UpdateUserCommand command)
        {
            var user = await _userRepository.GetById(command.Id);

            user.FirstName = command.FirstName;
            user.LastName = command.LastName;

            var result = await _userRepository.SaveAsync();

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<bool> HandleAsync(DeleteUserCommand command)
        {
            var user = await _userRepository.GetById(command.Id);

            _userRepository.DeleteUser(user);

            var result = await _userRepository.SaveAsync();

            return true;
        }
    }
}
