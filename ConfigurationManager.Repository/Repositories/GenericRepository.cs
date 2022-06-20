using ConfigurationManager.Core.Repositories;
using ConfigurationManager.Repository.Providers.MongoDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using MongoDB.Driver;
using ConfigurationManager.Repository.Providers.GenericContext.Interfaces;
using ConfigurationManager.Repository.Providers.GenericContext.Concrete;

namespace ConfigurationManager.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbset;
        protected readonly IGenericContext _mongoContext;
        protected readonly IMongoCollection<T> _collection;




        DbContextOptions<AppDbContext> sqlOptions;
        IOptions<DbConfiguration> mongoOptions;
        protected GenericContextOperation<T> _contextOperation = null;
        const string contextType = "MongoDb";

        public GenericRepository(GenericContextOperation<T> contextOperation)
        {
            /*_context = context;
            _dbset = _context.Set<T>();
            _mongoContext = mongoContext;
            _collection = _mongoContext.GetCollection<T>(typeof(T).Name);*/
            _contextOperation = contextOperation;
            if (contextType == "MongoDb")
            {
                _contextOperation = new GenericContextOperation<T>(new MongoContext(mongoOptions));
                _collection = _contextOperation.GetCollection(typeof(T).Name);
            }
            else if (contextType == "SqlDb")
            {
                _contextOperation = new GenericContextOperation<T>(new AppDbContext(sqlOptions));
            }
        }

        public async Task AddAsync(T entity)
        {
            //await _collection.InsertOneAsync(entity).ConfigureAwait(false);
            //await _mongoContext.AddCommand(async () => await _collection.InsertOneAsync(entity));
            await _contextOperation.AddCommand(async () => await _collection.InsertOneAsync(entity));
            //await _dbset.AddAsync(entity);

        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            if (_context == null)
            {
                await _mongoContext.AddCommand(async () => await _collection.InsertManyAsync(entities));
            }
            else
            {
                await _dbset.AddRangeAsync(entities);
            }
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
            if (_context == null)
            {
                var data = await _collection.FindAsync(Builders<T>.Filter.Eq("_id", id));
                return data.FirstOrDefault();
            }
            else
            {
                return await _dbset.FindAsync(id);
            }
        }

        public void Remove(T entity)
        {
            if (_context == null)
            {
                //mongoDb entity remove.
            }
            else
            {
                _dbset.Remove(entity);
            }
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
