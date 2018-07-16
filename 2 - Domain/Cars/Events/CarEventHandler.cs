using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Events.Cars;
using Domain.Shared.Events;
using MediatR;

namespace Domain.Events.Cars
{
    public class CarEventHandler :
    INotificationHandler<CreateCarEvent>,
    INotificationHandler<UpdateCarEvent>,
    INotificationHandler<DeleteCarEvent>
    {
        public async Task Handle(CreateCarEvent message, CancellationToken cancellationToken)
        {
            Console.WriteLine("Car create with success: " + message.MessageType, ConsoleColor.Green);
        }

        public async Task Handle(UpdateCarEvent message, CancellationToken cancellationToken)
        {
            Console.WriteLine("Car update with success: " + message.MessageType, ConsoleColor.Green);
        }

        public async Task Handle(DeleteCarEvent message, CancellationToken cancellationToken)
        {
            Console.WriteLine("Car delete with success: " + message.MessageType, ConsoleColor.Green);
        }
    }
}