using System;
using Domain.Events;
using static Domain.Shared.EntityEnum;

namespace Domain.Events.Cars
{
    public class UpdateCarEvent : BaseCarEvent
    {
        public UpdateCarEvent(object id, string name, decimal price, EStatus status)
        {
            ID = id;
            Name = name;
            Price = price;
            Status = status;

            AggregateID = id;
        }
    }
}