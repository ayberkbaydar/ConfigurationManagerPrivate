using MongoDB.Driver;

namespace ConfigurationManager.Core
{
    public interface IGenericContext<TContext, TDbSet>
    {
        public TContext Context { get; set; }
        public TDbSet DbSet { get; set; }
        public IMongoDatabase Database { get; set; }
        public List<Func<Task>> _commands { get; }
        public void RegisterConventions();
        public Task AddCommand();
        public void Dispose();
        public TDbSet GetCollection();
        public int SaveChanges();
        public Task<int> SaveChangesAsync();
    }
}
