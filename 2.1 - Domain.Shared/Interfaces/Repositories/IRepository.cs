using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Shared.ObjectValues;

namespace Domain.Shared.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {     
        object Create(T entity);
        Task<object> CreateAsync(T entity);   

        T Update(T t, object id);
        Task<T> UpdateAsyn(T t, object id);

        void Delete(object id);
        Task DeleteAsync(object id);

        T Get(object id);
        Task<T> GetAsync(object id);

        List<dynamic> GetAll(Filter filter);
        Task<List<dynamic>> GetAllAsync(Filter filter);        
    }
}