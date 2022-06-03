using ConfigurationManager.Core.Models;

namespace ConfigurationManager.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<List<User>> GetUsers();
    }
}
