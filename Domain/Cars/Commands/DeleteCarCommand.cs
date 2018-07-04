using System;

namespace Domain.Commands.Cars
{
    public class DeleteCarCommand : BaseCarCommand
    {
        public DeleteCarCommand(Guid id)
        {
            ID = id;
            AggregateID = ID;
        }
    }
}