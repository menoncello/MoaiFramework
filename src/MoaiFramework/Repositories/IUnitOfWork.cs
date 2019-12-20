namespace MoaiFramework.Repositories
{
    using System;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}