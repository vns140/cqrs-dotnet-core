using Domain.Shared;
using Domain.Shared.Entities;
using static Domain.Shared.EntityEnum;

namespace Domain.Entities
{
    public class Car : Entity
    {
        public Car(string name, decimal price, EStatus status, object tenant = null, object id = null) : base(status, tenant, id)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        
        public decimal Price { get; private set; }
    }
}