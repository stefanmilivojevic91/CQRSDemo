using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task<List<User>> GetByAsync(Expression<Func<User, bool>> predicate,
                                                  Expression<Func<User, User>> selector)
        {
            return _databaseContext
                .Users
                .Where(predicate)
                .Select(selector)
                .ToListAsync();
        }

        public Task<User> GetById(string id)
        {
            return _databaseContext.Users.SingleOrDefaultAsync(user => user.Id == id);
        }

        public void AddUser(User user)
        {
            _databaseContext.Users.Add(user);            
        }

        public void DeleteUser(User user)
        {
            _databaseContext.Users.Remove(user);
        }

        public Task<int> SaveAsync()
        {
            return _databaseContext.SaveChangesAsync();
        }
    }
}
