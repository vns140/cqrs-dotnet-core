using MediatR;

namespace Domain.Shared.Events
{
    public abstract class Message : INotification
    {
        public string MessageType { get; protected set; }
        public object AggregateID { get; protected set; }
        
        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}