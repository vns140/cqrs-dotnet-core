using System;
using Domain.Commands.Cars;
using Domain.Entities.Cars;
using Domain.Interfaces.Repositories.Cars;
using Domain.Shared.CommandHandlers;
using Domain.Shared.Events;
using Domain.Shared.Interfaces.Repositories;

namespace Domain.CommandHandlers.Cars
{
    public class CarCommandHandler : CommandHandler,
    IHandler<CreateCarCommand>,
    IHandler<UpdateCarCommand>,
    IHandler<DeleteCarCommand>
    {
        private readonly ICarRepository _carRepository;

        public CarCommandHandler(ICarRepository carRepository, 
                                 IUnitOfWork unitOfWork):base(unitOfWork)
        {
            _carRepository = carRepository;
        }

        public void Handle(CreateCarCommand message)
        {            
            var car = new Car(message.Name,message.Price,message.Status,message.Tenant,message.ID);
            
            if(!car.IsValid())
            {
                NotificationValidationError(car.Erros);
                return;
            }
            
            //TODO:
            //Validação de Negócio
            //exemplo : Esse carro já existe com o mesmo nome?

            //persistencia
            _carRepository.Create(car);

            if(Commit())
            {
                Console.WriteLine("Evento registrado com sucesso.");
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