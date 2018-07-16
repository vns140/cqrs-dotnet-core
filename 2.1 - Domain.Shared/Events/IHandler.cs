using System.Threading;
using System.Threading.Tasks;

namespace Domain.Shared.Events
{
    public interface IHandler<in T> where T : Message
    {
        Task Handle(T message, CancellationToken cancellationToken);
    }
}