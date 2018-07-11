using System;
using System.Threading.Tasks;
using Domain.Commands.Cars;
using Domain.Entities.Cars;
using Domain.Events.Cars;
using Domain.Interfaces.Repositories.Cars;
using Domain.Shared.Bus;
using Domain.Shared.CommandHandlers;
using Domain.Shared.Events;
using Domain.Shared.Interfaces.Repositories;
using Domain.Shared.Notifications;

namespace Domain.Commands.Cars
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

        public async Task HandleAsync(CreateCarCommand message)
        {
            var car = Car.Factory.NewCreate(message.Name, message.Price, message.Status, message.Tenant);

            if (!IsValid(car)) return;

            //TODO:
            //Validação de Negócio
            //exemplo : Esse carro já existe com o mesmo nome?

            await _carRepository.CreateAsync(car);

            if (Commit())
            {
                Console.WriteLine("Car register with success.");
                _bus.RaiseEvent(new CreateCarEvent(car.ID, car.Name, car.Price, car.Status, car.Tenant));
            }
        }
        public async Task HandleAsync(UpdateCarCommand message)
        {

            if (!await Exist(message.ID, message.MessageType)) return;

            var car = Car.Factory.NewUpdate(message.Name, message.Price, message.Status, message.Tenant, message.ID);

            if (!IsValid(car)) return;

            //TODO:
            //Validação de Negócio
            //exemplo : Esse carro já existe com o mesmo nome?

            _carRepository.Update(car, message.ID);

            if (Commit())
            {
                Console.WriteLine("Car update with success.");
                _bus.RaiseEvent(new UpdateCarEvent(car.ID, car.Name, car.Price, car.Status));
            }
        }
        public async Task HandleAsync(DeleteCarCommand message)
        {
            if (!await Exist(message.ID, message.MessageType)) return;

            await _carRepository.DeleteAsync(message.ID);

            if (Commit())
            {
                Console.WriteLine("Car delete with success.");
                _bus.RaiseEvent(new DeleteCarEvent(message.ID));
            }
        }

        private bool IsValid(Car car)
        {
            if (car.IsValid()) return true;
            else
            {
                NotificationValidationError(car.Erros);
                return false;
            }
        }

        private async Task<bool> Exist(object id, string messageType)
        {
            var car = await _carRepository.GetAsync(id);
            if (car != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Car not found."));
            return false;
        }
    }
}