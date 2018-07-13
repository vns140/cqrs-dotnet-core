using Domain.Shared;
using Domain.Shared.Entities;
using static Domain.Shared.EntityEnum;

namespace Domain.Entities.Cars
{
    public class Car : Entity
    {
        protected Car() { }
        private Car(string name, decimal price, EStatus status, object tenant, object id = null) : base(status, tenant, id)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public static class Factory
        {
            public static Car NewCreate(string name, decimal price, EStatus status, object tenant)
            {
                return new Car(name, price, status, tenant);
            }

            public static Car NewUpdate(string name, decimal price, EStatus status, object tenant, object id)
            {
                return new Car(name, price, status, tenant, id);
            }
        }

    }
}