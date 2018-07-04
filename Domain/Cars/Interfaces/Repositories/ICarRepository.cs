using Domain.Entities.Cars;
using Domain.Shared.Interfaces.Repositories;

namespace Domain.Interfaces.Repositories.Cars
{
    public interface ICarRepository : IRepositoryShared<Car>
    {
        
    }
}