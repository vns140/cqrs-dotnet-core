using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Shared.Events;

namespace Domain.Shared.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;
        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(DomainNotification message)
        {
            _notifications.Add(message);
             Console.WriteLine($"Erro: {message.Key} - {message.Value}", ConsoleColor.Green);
            
        }

        public bool HasNotifications()
        {
            return _notifications.Any(); 
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }

        
    }
}