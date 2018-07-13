using System;
using System.Collections.Generic;
using Domain.Shared.Bus;
using Domain.Shared.Interfaces.Repositories;
using Domain.Shared.Notifications;
using FluentValidation.Results;

namespace Domain.Shared.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;

        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            _bus = bus;
            _uow = uow;
            _notifications = notifications;
        }

        protected void NotificationValidationError(List<ValidationFailure> erros)
        {
            foreach (var error in erros)
            {
                Console.WriteLine(error.ErrorMessage, ConsoleColor.Red);
                _bus.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        protected bool Commit()
        {
            if (_notifications.HasNotifications()) return false;

            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;

            Console.WriteLine("Ocorreu um erro ao salvar os dados no banco.", ConsoleColor.Red);
            _bus.RaiseEvent(new DomainNotification("Commit", "Ocorreu um erro ao salvar os dados no banco."));
            return false;
        }
    }
}