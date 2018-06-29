using Domain.Shared.Entities;

namespace Domain.Entities
{
    public class Car : Entity
    {
        public string Name { get; private set; }
        
        public decimal Price { get; private set; }
    }
}