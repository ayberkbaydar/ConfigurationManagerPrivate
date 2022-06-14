using ConfigurationManager.Core.Models;
using ConfigurationManager.Core.MongoDbContext;
using ConfigurationManager.Core.Repositories;
using ConfigurationManager.Repository.Providers.MongoDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ConfigurationManager.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context, IMongoContext mongoContext) : base(context, mongoContext)
        {
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
