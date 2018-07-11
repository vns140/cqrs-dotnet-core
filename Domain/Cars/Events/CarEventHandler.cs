using System;
using System.Threading.Tasks;
using Domain.Events.Cars;
using Domain.Shared.Events;

namespace Domain.Events.Cars
{
    public class CarEventHandler :
    IHandler<CreateCarEvent>,
    IHandler<UpdateCarEvent>,
    IHandler<DeleteCarEvent>
    {
        public async Task HandleAsync(CreateCarEvent message)
        {
           Console.WriteLine("Car create with success: " + message.MessageType, ConsoleColor.Green);
        }

        public async Task HandleAsync(UpdateCarEvent message)
        {
           Console.WriteLine("Car update with success: " + message.MessageType, ConsoleColor.Green);
        }

        public async Task HandleAsync(DeleteCarEvent message)
        {
            Console.WriteLine("Car delete with success: " + message.MessageType, ConsoleColor.Green);
        }
    }
}