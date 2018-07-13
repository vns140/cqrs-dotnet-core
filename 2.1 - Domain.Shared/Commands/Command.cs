using System;
using Domain.Shared.Events;
using static Domain.Shared.EntityEnum;

namespace Domain.Shared.Commands
{
    public class Command : Message
    {
        public object ID { get; protected set; }
        public EStatus Status { get; protected set; }
        public object Tenant { get; protected set; }
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}