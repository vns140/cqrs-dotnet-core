using System;
using Domain.Shared.Validators;
using static Domain.Shared.EntityEnum;

namespace Domain.Shared.Entities
{
    public abstract class Entity : InfoValidator
    {
        protected Entity() { }
        protected Entity(EStatus status, object tenant = null, object id = null)
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

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;
            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return ID.Equals(compareTo.ID);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(null, a) && ReferenceEquals(null, b))
                return true;

            return a.Equals(b);

        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + ID.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + "[ID = " + ID + "]";
        }
    }
}