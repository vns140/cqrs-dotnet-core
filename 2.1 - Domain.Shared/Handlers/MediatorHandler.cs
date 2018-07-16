using System.Threading.Tasks;
using Domain.Shared.Commands;
using Domain.Shared.Events;
using Domain.Shared.Interfaces.Handlers;
using MediatR;

namespace Domain.Shared.Handlers
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        //IventStore - implementar

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task PublishCommand<T>(T cmd) where T : Command
        {
            return Publish(cmd);
        }

        public Task PublishEvent<T>(T evt) where T : Event
        {
            if(!evt.MessageType.Equals("DomainNotification"))
            {
                //event store
            }

            return Publish(evt);
        }

        private Task Publish<T>(T message) where T : Message
        {
            return _mediator.Publish(message);
        }
    }
}