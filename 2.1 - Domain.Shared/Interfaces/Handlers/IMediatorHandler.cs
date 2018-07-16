using System.Threading.Tasks;
using Domain.Shared.Events;
using Domain.Shared.Commands;

namespace Domain.Shared.Interfaces.Handlers
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T evt) where T : Event;
        Task PublishCommand<T> (T cmd) where T : Command;
    }
}