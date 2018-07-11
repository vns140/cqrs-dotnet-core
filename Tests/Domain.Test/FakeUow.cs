using Domain.Shared.Bus;
using Domain.Shared.Commands;
using Domain.Shared.Events;
using Domain.Shared.Interfaces.Repositories;
using Domain.Shared.Notifications;

namespace Domain.Test
{
    public class FakeUow : IUnitOfWork
    {
        public CommandResponse Commit()
        {
            return new CommandResponse(true);
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}