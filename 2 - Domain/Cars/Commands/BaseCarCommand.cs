using Domain.Shared.Commands;
using static Domain.Shared.EntityEnum;

namespace Domain.Commands.Cars
{
    public abstract class BaseCarCommand : Command
    {
        public string Name { get; protected set; }
        
        public decimal Price { get; protected set; }
    }
}