using ConfigurationManager.Core.Repositories;
using ConfigurationManager.Repository.Providers.MongoDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace ConfigurationManager.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbset;
        internal readonly IMongoCollection<T> _collection;
        private readonly DbConfiguration _options;

        public GenericRepository(AppDbContext context, IOptions<DbConfiguration> options)
        {
            _context = context;
            _dbset = _context.Set<T>();
            _options = options.Value;
            var client = new MongoClient(_options.ConnectionString);
            var database = client.GetDatabase(_options.DatabaseName);
            _collection = database.GetCollection<T>(_options.CollectionName);
        }
        //public GenericRepository(IOptions<DbConfiguration> options)
        //{
        //    _options = options.Value;
        //    var client = new MongoClient(_options.ConnectionString);
        //    var database = client.GetDatabase(_options.DatabaseName);
        //    _collection = database.GetCollection<T>(_options.CollectionName);
        //}

        public async Task AddAsync(T entity)
        {
            if (_context == null)
            {
                await _collection.InsertOneAsync(entity).ConfigureAwait(false);
            }
            else
            {
                await _dbset.AddAsync(entity);
            }
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbset.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbset.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _dbset.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbset.Where(expression);
        }
    }
}
