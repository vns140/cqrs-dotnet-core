using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Shared.Entities;
using Domain.Shared.Interfaces.Repositories;
using Domain.Shared.ObjectValues;

namespace Fujitsu.Funeral.Repositories
{
    public class RepositoryShared<T> : IRepository<T> where T : Entity
    {
        public RepositoryShared()
        {
        }

        public object Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<object> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public T Get(object id)
        {
            throw new NotImplementedException();
        }

        public List<dynamic> GetAll(Filter filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<dynamic>> GetAllAsync(Filter filter)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(object id)
        {
            throw new NotImplementedException();
        }

        public T Update(T t, object id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsyn(T t, object id)
        {
            throw new NotImplementedException();
        }
    }
}