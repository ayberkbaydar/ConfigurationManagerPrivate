using ConfigurationManager.Repository.Providers.GenericContext.Interfaces;
using MongoDB.Driver;

namespace ConfigurationManager.Repository.Providers.GenericContext.Concrete
{
    public class GenericContextOperation<T>
    {
        protected readonly IGenericContext _genericContext;
        public GenericContextOperation(IGenericContext genericContext)
        {
            _genericContext = genericContext;
        }
        public Task AddCommand(Func<Task> func)
        {
            return _genericContext.AddCommand(func);
        }
        public int SaveChanges()
        {
            return _genericContext.SaveChanges();
        }
        public Task<int> SaveChangesAsync()
        {
            return _genericContext.SaveChangesAsync();
        }
        public IMongoCollection<T> GetCollection(string name)
        {
            return _genericContext.GetCollection<T>(name);
        }
    }
}
