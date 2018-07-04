using System;

namespace Domain.Commands
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