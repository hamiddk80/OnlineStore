

namespace Contracts
{
    public interface IUniOfWork
    {
        Task<int> Commit();
    }
}
