using System;
using Domain.Shared.Events;
using static Domain.Shared.EntityEnum;

namespace Domain.Events.Cars
{
    public class CreateCarEvent : BaseCarEvent
    {
        public CreateCarEvent(Guid id, string name, decimal price, EStatus status, Guid tenant)
        {
            ID = id;
            Name = name;
            Price = price;
            Status = status;
            Tenant = tenant;
            AggregateID = id;
        }
    }
}