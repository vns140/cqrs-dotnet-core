using Domain.Shared.Events;

namespace Domain.Events.Cars
{
    public abstract class BaseCarEvent : Event
    {
        public string Name { get; protected set; }
        
        public decimal Price { get; protected set; }
        
    }
}