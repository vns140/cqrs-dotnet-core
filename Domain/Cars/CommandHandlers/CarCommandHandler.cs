using System;
using Domain.Commands.Cars;
using Domain.Entities.Cars;
using Domain.Events.Cars;
using Domain.Interfaces.Repositories.Cars;
using Domain.Shared.Bus;
using Domain.Shared.CommandHandlers;
using Domain.Shared.Events;
using Domain.Shared.Interfaces.Repositories;
using Domain.Shared.Notifications;

namespace Domain.CommandHandlers.Cars
{
    public class CarCommandHandler : CommandHandler,
    IHandler<CreateCarCommand>,
    IHandler<UpdateCarCommand>,
    IHandler<DeleteCarCommand>
    {
        private readonly ICarRepository _carRepository;
        private readonly IBus _bus;

        public CarCommandHandler(ICarRepository carRepository,
                                 IUnitOfWork unitOfWork,
                                 IBus bus,
                                 IDomainNotificationHandler<DomainNotification> notifications) : base(unitOfWork, bus, notifications)
        {
            _carRepository = carRepository;
            _bus = bus;
        }

        public void Handle(CreateCarCommand message)
        {
            var car = new Car(message.Name, message.Price, message.Status, message.Tenant, message.ID);

            if (!car.IsValid())
            {
                NotificationValidationError(car.Erros);
                return;
            }

            //TODO:
            //Validação de Negócio
            //exemplo : Esse carro já existe com o mesmo nome?

            //persistencia
            _carRepository.Create(car);

            if (Commit())
            {
                Console.WriteLine("Evento registrado com sucesso.");
                _bus.RaiseEvent(new CreateCarEvent(car.ID, car.Name, car.Price, car.Status, car.Tenant));
            }
        }
        public void Handle(UpdateCarCommand message)
        {
            throw new System.NotImplementedException();
        }
        public void Handle(DeleteCarCommand message)
        {
            throw new System.NotImplementedException();
        }
    }
}