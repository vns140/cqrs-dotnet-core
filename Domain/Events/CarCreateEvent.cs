using System;
using Domain.Shared.Events;
using static Domain.Shared.EntityEnum;

namespace Domain.Events
{
    public class CarCreateEvent : CarEvent
    {
        public CarCreateEvent(Guid id, string name, decimal price, EStatus status)
        {
            ID = id;
            Name = name;
            Price = price;
            Status = status;
            AggregateID = id;
        }
        
    }
}