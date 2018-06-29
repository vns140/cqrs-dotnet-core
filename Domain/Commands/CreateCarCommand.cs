using System;
using static Domain.Shared.EntityEnum;

namespace Domain.Commands
{
    public class CreateCarCommand : CarCommand
    {
        public CreateCarCommand(string nome,decimal price, EStatus status, Guid tenant)
        {
            Nome = nome;
            Price = price;
            Status = status;
            Tenant = tenant;
        }
    }
}