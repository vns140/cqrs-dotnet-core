using System;
using static Domain.Shared.EntityEnum;

namespace Domain.Commands
{
    public class CreateCarCommand : CarCommand
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