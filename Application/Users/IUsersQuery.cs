using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Users
{
    public interface IUsersQuery
    {
        Task<IEnumerable<UserDto>> FindBy(UserDto model);
        Task<UserDto> FindById(string id);
    }
}
