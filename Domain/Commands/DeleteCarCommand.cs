using System;

namespace Domain.Commands
{
    public class DeleteCarCommand : CarCommand
    {
        public DeleteCarCommand(Guid id)
        {
            ID = id;
            AggregateID = ID;
        }
    }
}