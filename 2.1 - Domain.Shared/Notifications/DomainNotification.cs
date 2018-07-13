using System;
using Domain.Shared.Events;

namespace Domain.Shared.Notifications
{
    public class DomainNotification : Event
    {
        public DomainNotification( string key, string value)
        {
            NotificationID = Guid.NewGuid();
            Key = key;
            Value = value;
            Version = 1;
        }

        public Guid NotificationID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int Version { get; set; }
    }
}