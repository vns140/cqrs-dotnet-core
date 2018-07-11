using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities.Cars;
using Domain.Interfaces.Repositories.Cars;
using Domain.Shared.ObjectValues;
using static Domain.Shared.EntityEnum;

namespace Domain.Test
{
    public class FakeRepository : ICarRepository
    {
        public bool Any(Expression<Func<Car, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<Car, bool>> match)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public object Create(Car entity)
        {
            return null;
        }

        public Task<object> CreateAsync(Car entity)
        {
            return null;
        }

        public void CreateRange(List<Car> entities)
        {
            throw new NotImplementedException();
        }

        public Task CreateRangeAsync(List<Car> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            
        }

        public Task DeleteAsync(object id)
        {
            return null;
        }

        public Car Find(Expression<Func<Car, bool>> match)
        {
            throw new NotImplementedException();
        }

        public ICollection<Car> FindAll(Expression<Func<Car, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Car>> FindAllAsync(Expression<Func<Car, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<Car> FindAsync(Expression<Func<Car, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Car Get(object id)
        {
            return Car.Factory.NewCreate("Fox Rock in Rio", 19000, EStatus.Ativo, Guid.NewGuid());
        }

        public List<dynamic> GetAll(Filter filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<dynamic>> GetAllAsync(Filter filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Car> GetAsync(object id)
        {
            
            return Car.Factory.NewCreate("Fox Rock in Rio", 19000, EStatus.Ativo, Guid.NewGuid());
        }

        public object Save()
        {
            throw new NotImplementedException();
        }

        public Task<object> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Car Update(Car t, object id)
        {
            return null;
        }

        public Task<Car> UpdateAsyn(Car t, object id)
        {
            return null;
        }
    }
}