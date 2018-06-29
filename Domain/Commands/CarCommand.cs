using Domain.Shared.Commands;
using static Domain.Shared.EntityEnum;

namespace Domain.Commands
{
    public abstract class CarCommand : Command
    {
        public string Nome { get; protected set; }
        
        public decimal Price { get; protected set; }
    }
}