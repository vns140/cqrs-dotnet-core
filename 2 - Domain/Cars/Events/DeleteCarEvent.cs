using System;
using Domain.Events;
using static Domain.Shared.EntityEnum;

namespace Domain.Events.Cars
{
    public class DeleteCarEvent : BaseCarEvent
    {
        public DeleteCarEvent(object id)
        {
            ID = id;
            AggregateID = id;
        }
    }
}