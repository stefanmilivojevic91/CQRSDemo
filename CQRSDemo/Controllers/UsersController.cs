using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Users;
using Application.Users.Commands;
using Microsoft.AspNetCore.Mvc;
using WebApi.Requests;
using WebApi.Responses;

namespace CQRSDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersQuery _usersQuery;
        private readonly IUsersCommandHandler _usersCommandHandler;

        public UsersController(IUsersQuery usersQuery,
                               IUsersCommandHandler usersCommandHandler)
        {
            _usersQuery = usersQuery;
            _usersCommandHandler = usersCommandHandler;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] UsersFilter filter)
        {
            var model = new UserDto
            {
                Id = filter.Id,
                FirstName = filter.FirstName,
                LastName = filter.LastName
            };

            var users = await _usersQuery.FindBy(model);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var user = await _usersQuery.FindById(id);

            return Ok(new UserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            }); ;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserModel model)
        {
            var command = new AddUserCommand
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _usersCommandHandler.HandleAsync(command);

            return Ok(new UserResponse
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] UserModel model)
        {
            var command = new UpdateUserCommand
            {
                Id = id,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _usersCommandHandler.HandleAsync(command);

            return Ok(new UserResponse
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var command = new DeleteUserCommand
            {
                Id = id
            };

            var result = await _usersCommandHandler.HandleAsync(command);

            return Ok(new
            {
                Deleted = result
            });
        }
    }
}
