namespace ConfigurationManager.Core.UnitOfWorks
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        Task CommitAsync();
        void Commit();
    }
}
