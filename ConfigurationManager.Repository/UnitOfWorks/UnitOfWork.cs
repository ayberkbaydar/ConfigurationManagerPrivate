using ConfigurationManager.Core.MongoDbContext;
using ConfigurationManager.Core.UnitOfWorks;

namespace ConfigurationManager.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IMongoContext _mongoContext;
        public UnitOfWork(AppDbContext context, IMongoContext mongoContext)
        {
            _context = context;
            _mongoContext = mongoContext;
        }
        public void Commit()
        {
            //_context.SaveChanges();
            _mongoContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            //await _context.SaveChangesAsync();
            await _mongoContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            //_context.Dispose();
            _mongoContext.Dispose();
        }
    }
}
