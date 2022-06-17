using ConfigurationManager.Core;
using ConfigurationManager.Core.Models;
using ConfigurationManager.Core.MongoDbContext;
using ConfigurationManager.Core.Repositories;
using MongoDB.Driver;

namespace ConfigurationManager.Repository.Repositories
{
    public class UserRepository : GenericRepository<IMongoContext,IMongoCollection<User>,User>, IUserRepository
    {
        //public UserRepository(AppDbContext context, IMongoContext mongoContext) : base(context, mongoContext)
        //{
        //}
        public UserRepository(IGenericContext<IMongoContext, IMongoCollection<User>> genericContext)
        {

        }

        public async Task<List<User>> GetUsers()
        {
            //return await _context.Users.ToListAsync();
            return new List<User>();
        }
    }
}
