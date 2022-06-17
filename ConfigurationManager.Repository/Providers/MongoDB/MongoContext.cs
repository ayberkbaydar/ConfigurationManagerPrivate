using ConfigurationManager.Core.MongoDbContext;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using ConfigurationManager.Core.Models;
using ConfigurationManager.Core;

namespace ConfigurationManager.Repository.Providers.MongoDB
{
    public class MongoContext : /*IMongoContext,*/ IGenericContext<IMongoContext, IMongoCollection<User>>
    {
        //protected readonly IMongoContext _context;
        //protected readonly IMongoCollection<User> _dbSet;
        //private readonly IOptions<DbConfiguration> _options;
        private IMongoDatabase Database { get; set; }
        public IMongoContext Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IMongoCollection<User> DbSet { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IMongoDatabase IGenericContext<IMongoContext, IMongoCollection<User>>.Database { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        List<Func<Task>> IGenericContext<IMongoContext, IMongoCollection<User>>._commands => throw new NotImplementedException();

        private readonly List<Func<Task>> _commands;
        public MongoContext(IOptions<DbConfiguration> options)
        {
            // Set Guid to CSharp style (with dash -)
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
            // Every command will be stored and it'll be processed at SaveChanges
            _commands = new List<Func<Task>>();

            RegisterConventions();

            //_options = options;
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            Database = mongoClient.GetDatabase(options.Value.DatabaseName);
            //_context = this;
            Context = this;
            //_dbSet = _context.GetCollection<User>(typeof(User).Name);
            DbSet = Context.GetCollection<User>(typeof(User).Name);
        }

        //Persistence
        private void RegisterConventions()
        {
            var pack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfDefaultConvention(true)
            };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }

        //public Task AddCommand(Func<Task> func)
        //{
        //    _commands.Add(func);
        //    return Task.CompletedTask;
        //}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        //public IMongoCollection<T> GetCollection<T>(string name)
        //{
        //    return Database.GetCollection<T>(name);
        //}

        public int SaveChanges()
        {
            var qtd = _commands.Count;
            foreach (var command in _commands)
            {
                command();
            }
            _commands.Clear();
            return qtd;
        }

        public async Task<int> SaveChangesAsync()
        {
            var qtd = _commands.Count;
            foreach (var command in _commands)
            {
                await command();
            }
            _commands.Clear();
            return qtd;
        }

        public IMongoContext CreateContext()
        {
            return Context;
        }

        public IMongoCollection<User> CreateDbSet()
        {
            return DbSet;
        }

        void IGenericContext<IMongoContext, IMongoCollection<User>>.RegisterConventions()
        {
            throw new NotImplementedException();
        }

        public Task AddCommand()
        {
            throw new NotImplementedException();
        }

        public IMongoCollection<User> GetCollection()
        {
            throw new NotImplementedException();
        }
    }
}
