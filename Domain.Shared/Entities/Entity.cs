using System;
using Domain.Shared.Validators;
using static Domain.Shared.EntityEnum;

namespace Domain.Shared.Entities
{
    public abstract class Entity : InfoValidator
    {        
        protected Entity() { }
        public Entity(EStatus status, object tenant = null, object id = null)
        {
            if (id == null)
            {
                ID = Guid.NewGuid();
            }
            else
            {
                ID = id;
            }

            Tenant = tenant;
            Status = status;
        }

        public object ID { get; protected set; }
        public object Tenant { get; protected set; }
        public EStatus Status { get; protected set; }

        protected void NewGuid()
        {
            ID = Guid.NewGuid();
        }
    }
}