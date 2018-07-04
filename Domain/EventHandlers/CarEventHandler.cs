using Domain.Events;
using Domain.Shared.Events;

namespace Domain.EventHandlers
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