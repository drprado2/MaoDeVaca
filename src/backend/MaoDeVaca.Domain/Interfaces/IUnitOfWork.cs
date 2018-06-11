using System.Threading.Tasks;

namespace MaoDeVaca.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
