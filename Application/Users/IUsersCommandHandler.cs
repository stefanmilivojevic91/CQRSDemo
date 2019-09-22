using Application.Dtos;
using Application.Users.Commands;
using System.Threading.Tasks;

namespace Application.Users
{
    public interface IUsersCommandHandler
    {
        Task<UserDto> HandleAsync(AddUserCommand command);
        Task<UserDto> HandleAsync(UpdateUserCommand command);
        Task<bool> HandleAsync(DeleteUserCommand command);
    }
}
