using ConfigurationManager.Core.Models;
using ConfigurationManager.Core.Repositories;
using ConfigurationManager.Repository.Providers.GenericContext.Concrete;
using ConfigurationManager.Repository.Providers.GenericContext.Interfaces;
using ConfigurationManager.Repository.Providers.MongoDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ConfigurationManager.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(GenericContextOperation<User> genericContextOperation) : base(genericContextOperation)
        {
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
