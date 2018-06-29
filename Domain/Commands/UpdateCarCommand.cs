using System;
using static Domain.Shared.EntityEnum;

namespace Domain.Commands
{
    public class UpdateCarCommand : CarCommand
    {
        public UpdateCarCommand(Guid id, string nome, decimal price, EStatus status)
        {
            ID = id;
            Nome = nome;
            Price = price;
            Status = status;
        }
    }
}