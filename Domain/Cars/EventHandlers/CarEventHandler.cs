using Domain.Events.Cars;
using Domain.Shared.Events;

namespace Domain.EventHandlers.Cars
{
    public class CarEventHandler :
    IHandler<CreateCarEvent>,
    IHandler<UpdateCarEvent>,
    IHandler<DeleteCarEvent>
    {
        public void Handle(CreateCarEvent message)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(UpdateCarEvent message)
        {
            throw new System.NotImplementedException();
        }

        public void Handle(DeleteCarEvent message)
        {
            throw new System.NotImplementedException();
        }
    }
}