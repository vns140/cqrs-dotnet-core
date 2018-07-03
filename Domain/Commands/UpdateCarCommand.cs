using System;
using static Domain.Shared.EntityEnum;

namespace Domain.Commands
{
    public class UpdateCarCommand : CarCommand
    {
        public UpdateCarCommand(Guid id, string name, decimal price, EStatus status)
        {
            ID = id;
            Name = name;
            Price = price;
            Status = status;
        }
    }
}