using System;
using static Domain.Shared.EntityEnum;

namespace Domain.Shared.Events
{
    public abstract class Event : Message
    {
        protected Event()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; protected set; }
        public object ID { get; protected set; }
        public EStatus Status { get; protected set; }
        public object Tenant { get; protected set; }
    }
}