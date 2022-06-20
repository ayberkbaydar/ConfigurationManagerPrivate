using MongoDB.Driver;

namespace ConfigurationManager.Repository.Providers.GenericContext.Interfaces
{
    public interface IGenericContext : IDisposable
    {
        Task AddCommand(Func<Task> func);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
