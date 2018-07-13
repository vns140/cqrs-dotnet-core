using System;
using static Domain.Shared.EntityEnum;

namespace Domain.Commands.Cars
{
    public class UpdateCarCommand : BaseCarCommand
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