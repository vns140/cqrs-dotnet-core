using System;
using Domain.Events;
using static Domain.Shared.EntityEnum;

namespace Domain.Events
{
    public class UpdateCarEvent : BaseCarEvent
    {
        public UpdateCarEvent(Guid id, string name, decimal price, EStatus status)
        {
            ID = id;
            Name = name;
            Price = price;
            Status = status;

            AggregateID = id;
        }
    }
}