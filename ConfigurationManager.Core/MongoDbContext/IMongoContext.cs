using MongoDB.Driver;

namespace ConfigurationManager.Core.MongoDbContext
{
    public interface IMongoContext : IDisposable
    {
        Task AddCommand(Func<Task> func);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
