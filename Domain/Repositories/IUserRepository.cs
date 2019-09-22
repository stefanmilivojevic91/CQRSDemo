using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetByAsync(Expression<Func<User, bool>> predicate, 
                                    Expression<Func<User, User>> selector);

        Task<User> GetById(string id);

        void AddUser(User user);

        Task<int> SaveAsync();

        void DeleteUser(User user);
    }
}
