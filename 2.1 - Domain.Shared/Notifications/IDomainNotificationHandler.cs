using System.Collections.Generic;
using Domain.Shared.Events;

namespace Domain.Shared.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T: Message
    {
         bool HasNotifications();
         List<T> GetNotifications();
    }
}