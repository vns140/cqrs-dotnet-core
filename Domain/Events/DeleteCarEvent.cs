using System;
using Domain.Events;
using static Domain.Shared.EntityEnum;

namespace Domain.Events
{
    public class DeleteCarEvent : BaseCarEvent
    {
        public DeleteCarEvent(Guid id)
        {
            ID = id;
            AggregateID = id;
        }
    }
}