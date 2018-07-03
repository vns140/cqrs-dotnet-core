using System;
using Domain.Shared.Commands;

namespace Domain.Shared.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
         CommandResponse Commit();
    }
}