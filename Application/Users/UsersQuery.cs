using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Commons;
using Application.Dtos;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Users
{
    public class UsersQuery : IUsersQuery
    {
        private readonly IUserRepository _userRepository;

        public UsersQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> FindBy(UserDto filter)
        {
            Expression<Func<User, bool>> predicate = user => true;

            if (!string.IsNullOrWhiteSpace(filter.Id))
            {
                Expression<Func<User, bool>> idExpression = user => user.Id == filter.Id;

                predicate = predicate.And(idExpression);
            }

            if (!string.IsNullOrWhiteSpace(filter.FirstName))
            {
                Expression<Func<User, bool>> firstNameExpression = user => string.Equals(user.FirstName, filter.FirstName, StringComparison.OrdinalIgnoreCase);

                predicate = predicate.And(firstNameExpression);
            }

            if (!string.IsNullOrWhiteSpace(filter.LastName))
            {
                Expression<Func<User, bool>> lastNameExpression = user => string.Equals(user.LastName, filter.LastName, StringComparison.OrdinalIgnoreCase);

                predicate = predicate.And(lastNameExpression);
            }

            Expression<Func<User, User>> projection = user => new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            var users = await _userRepository.GetByAsync(predicate, projection);

            return users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            });
        }

        public async Task<UserDto> FindById(string id)
        {
            var user = await _userRepository.GetById(id);

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
    }
}
