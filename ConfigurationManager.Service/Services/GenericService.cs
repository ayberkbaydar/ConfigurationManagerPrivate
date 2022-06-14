using ConfigurationManager.Core.Repositories;
using ConfigurationManager.Core.Services;
using ConfigurationManager.Core.UnitOfWorks;
using ConfigurationManager.Repository.Providers.MongoDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace ConfigurationManager.Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : class, new()
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMongoCollection<T> _mongoCollection;
        private readonly IOptions<DbConfiguration> _options;

        public GenericService(IGenericRepository<T> repository, IUnitOfWork unitOfWork, IOptions<DbConfiguration> options)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _options = options;
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
            _mongoCollection = mongoDatabase.GetCollection<T>(options.Value.CollectionName);
        }

        public async Task<T> AddAsync(T entity)
        {
            if (_options == null)
            {
                await _repository.AddAsync(entity);
                await _unitOfWork.CommitAsync();
                return entity;
            }
            else
            {
                await _mongoCollection.InsertOneAsync(entity);
                return entity;
            }

        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var hasProduct = await _repository.GetByIdAsync(id);
            if (hasProduct == null)
            {
                //notfound
            }
            return hasProduct;
        }

        public async Task RemoveAsync(T entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
