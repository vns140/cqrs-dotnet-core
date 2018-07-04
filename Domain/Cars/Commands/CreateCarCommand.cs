using System;
using static Domain.Shared.EntityEnum;

namespace Domain.Commands.Cars
{
    public class CreateCarCommand : BaseCarCommand
    {
        public CreateCarCommand(string name,decimal price, EStatus status, Guid tenant)
        {
            Name = name;
            Price = price;
            Status = status;
            Tenant = tenant;
        }
    }
}