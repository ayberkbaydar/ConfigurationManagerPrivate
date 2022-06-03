using ConfigurationManager.Core.Models;
using ConfigurationManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationManager.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
