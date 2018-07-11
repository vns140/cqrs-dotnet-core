using Domain.Commands.Cars;
using Domain.Events.Cars;
using Domain.Shared.Bus;
using Domain.Shared.Commands;
using Domain.Shared.Events;
using Domain.Shared.Notifications;

namespace Domain.Test
{
    public class FakeBus : IBus
    {
        public void RaiseEvent<T>(T theEvent) where T : Event
        {
            Publish(theEvent);
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
        }

        private static void Publish<T>(T message) where T : Message
        {
            var msgType = message.MessageType;

            if (msgType.Equals("DomainNotification"))
            {
                var obj = new DomainNotificationHandler();
                ((IDomainNotificationHandler<T>)obj).HandleAsync(message);
            }

            if (msgType.Equals("CreateCarCommand") ||
                msgType.Equals("DeleteCarCommand") ||
                msgType.Equals("UpdateCarCommand"))
            {
                var obj = new CarCommandHandler(new FakeRepository(),new FakeUow(),new FakeBus(),new DomainNotificationHandler());
                ((IHandler<T>)obj).HandleAsync(message);
            }

            if (msgType.Equals("CreateCarEvent") ||
                msgType.Equals("DeleteCarEvent") ||
                msgType.Equals("UpdateCarEvent"))
            {
                var obj = new CarEventHandler();
                ((IHandler<T>)obj).HandleAsync(message);
            }


        }
    }
}