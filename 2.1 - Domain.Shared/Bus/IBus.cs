using Domain.Shared.Commands;
using Domain.Shared.Events;

namespace Domain.Shared.Bus
{
    public interface IBus
    {
         void SendCommand<T>(T theCommand) where T : Command;

         void RaiseEvent<T>(T theEvent) where T : Event;
    }
}