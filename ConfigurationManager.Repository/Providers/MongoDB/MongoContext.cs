using ConfigurationManager.Core.MongoDbContext;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace ConfigurationManager.Repository.Providers.MongoDB
{
    public class MongoContext : IMongoContext
    {
        private readonly IOptions<DbConfiguration> _options;
        private IMongoDatabase Database { get; set; }
        private readonly List<Func<Task>> _commands;
        public MongoContext(IOptions<DbConfiguration> options)
        {
            // Set Guid to CSharp style (with dash -)
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;

            // Every command will be stored and it'll be processed at SaveChanges
            _commands = new List<Func<Task>>();

            RegisterConventions();

            _options = options;
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            Database = mongoClient.GetDatabase(options.Value.DatabaseName);
        }

        //Persistance
        private void RegisterConventions()
        {
            var pack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfDefaultConvention(true)
            };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }

        public Task AddCommand(Func<Task> func)
        {
            _commands.Add(func);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

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
    }
}
