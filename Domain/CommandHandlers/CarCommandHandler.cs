using Domain.Commands;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Shared.CommandHandlers;
using Domain.Shared.Events;
using Domain.Shared.Interfaces.Repositories;

namespace Domain.CommandHandlers
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
            //exemplo : Um motorsta é maior de 18?

            //persistencia
            _carRepository.Create(car);

            if(Commit())
            {
                //Notificar processo concluído
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