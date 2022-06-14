namespace ConfigurationManager.Core.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
        void Commit();
    }
}
