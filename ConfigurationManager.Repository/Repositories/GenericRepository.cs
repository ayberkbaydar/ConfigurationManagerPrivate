using ConfigurationManager.Core.Repositories;
using System.Linq.Expressions;
using MongoDB.Driver;
using ConfigurationManager.Core.MongoDbContext;
using ConfigurationManager.Repository.Providers.MongoDB;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationManager.Repository.Repositories
{
    public class GenericRepository<TContext, TDbSet, T> : IGenericRepository<T> where T : class, new()
    {
        readonly GenericContextOperation<TContext, TDbSet> contextOperation = null;
        readonly string contextType = "MongoDb";
        private readonly object _context;
        private readonly object _dbSet;
        public IOptions<DbConfiguration> _options;
        public DbContextOptions<AppDbContext> _dbContextOptions;
        public GenericRepository(/*IGenericContext<TContext, TDbSet> genericContext*/)
        {
            if (contextType == "MongoDb")
            {
                contextOperation = new GenericContextOperation<IMongoContext, IMongoCollection<T>>(new MongoContext(_options));
            }
            else if (contextType == "EntityFramework")
            {
                contextOperation = new GenericContextOperation<AppDbContext, DbSet<T>>(new AppDbContext(_dbContextOptions));
            }
            _context = contextOperation.CreateContext();
            _dbSet = contextOperation.CreateDbSet();
        }

        public async Task AddAsync(T entity)
        {
            var q = (IMongoContext)_context;
            var s = (IMongoCollection<T>)_dbSet;
            await q.AddCommand(async () => await s.InsertOneAsync(entity));
            //await _dbset.AddAsync(entity);

        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            var q = (IMongoContext)_context;
            var s = (IMongoCollection<T>)_dbSet;
            await q.AddCommand(async () => await s.InsertManyAsync(entities));
            //await _dbset.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            //return await _dbset.AnyAsync(expression);
            return true;
        }

        public IQueryable<T> GetAll()
        {
            //return _dbset.AsNoTracking().AsQueryable();
            IQueryable<T> empty = new T[] { }.AsQueryable();
            return empty;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            //if (_context == null)
            //{
            //    var data = await _collection.FindAsync(Builders<T>.Filter.Eq("_id", id));
            //    return data.FirstOrDefault();
            //}
            //else
            //{
            //    return await _dbset.FindAsync(id);
            //}
            return new T();
        }

        public void Remove(T entity)
        {
            //if (_context == null)
            //{
            //    //mongoDb entity remove.
            //}
            //else
            //{
            //    _dbset.Remove(entity);
            //}
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            //_dbset.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            //_dbset.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            //return _dbset.Where(expression);
            IQueryable<T> empty = new T[] { }.AsQueryable();
            return empty;
        }
    }
}
