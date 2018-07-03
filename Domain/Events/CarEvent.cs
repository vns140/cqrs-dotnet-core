using Domain.Shared.Events;

namespace Domain.Events
{
    public class CarEvent : Event
    {
        public string Name { get; protected set; }
        
        public decimal Price { get; protected set; }
        
    }
}