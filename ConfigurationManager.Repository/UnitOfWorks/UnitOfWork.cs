using ConfigurationManager.Core;
using ConfigurationManager.Core.MongoDbContext;
using ConfigurationManager.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace ConfigurationManager.Repository.UnitOfWorks
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        //private readonly AppDbContext _context;
        //private readonly IMongoContext _mongoContext;
        //public UnitOfWork(AppDbContext context, IMongoContext mongoContext)
        //{
        //    _context = context;
        //    _mongoContext = mongoContext;
        //}

        //private readonly object _context;
        protected readonly IMongoContext _mongoContext;
        protected readonly AppDbContext _sqlContext;

        public UnitOfWork(IGenericContext<IMongoContext, IMongoCollection<T>> genericContext)
        {
            _mongoContext = genericContext.CreateContext();
        }
        public UnitOfWork(IGenericContext<AppDbContext, DbSet<T>> genericContext)
        {
            _sqlContext = genericContext.CreateContext();
        }
        public void Commit()
        {
            _mongoContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _mongoContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _mongoContext.Dispose();
        }
    }
}
