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
        /// <summary>
        /// Cria um registro.
        /// </summary>
        /// <param name="entity">Entidade a ser criada</param>
        /// <returns>um objeto</returns>
        object Create(T entity);

        /// <summary>
        /// Cria um registro de forma assyncrona.
        /// </summary>
        /// <param name="entity">Entidade a ser criada</param>
        /// <returns>um objeto</returns>
        Task<object> CreateAsync(T entity);        

        /// <summary>
        /// Cria N registros
        /// </summary>
        /// <param name="entities"></param>
        void CreateRange(List<T> entities);
        Task CreateRangeAsync(List<T> entities);

        T Update(T t, object id);
        Task<T> UpdateAsyn(T t, object id);

        void Delete(object id);
        Task DeleteAsync(object id);

        T Get(object id);
        Task<T> GetAsync(object id);

        List<dynamic> GetAll(Filter filter);
        Task<List<dynamic>> GetAllAsync(Filter filter);


        int Count();
        Task<int> CountAsync();

        bool Any(Expression<Func<T, bool>> match);
        Task<bool> AnyAsync(Expression<Func<T, bool>> match);

        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);

        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

        object Save();
        Task<object> SaveAsync();
    }
}