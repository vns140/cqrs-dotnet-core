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
        public  void Handle(CreateCarEvent message)
        {
           Console.WriteLine("Car create with success: " + message.MessageType, ConsoleColor.Green);
        }

        public  void Handle(UpdateCarEvent message)
        {
           Console.WriteLine("Car update with success: " + message.MessageType, ConsoleColor.Green);
        }

        public  void Handle(DeleteCarEvent message)
        {
            Console.WriteLine("Car delete with success: " + message.MessageType, ConsoleColor.Green);
        }
    }
}