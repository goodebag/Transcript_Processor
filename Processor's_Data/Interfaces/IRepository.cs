using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Processor_s_Data.Interfaces
{
    public interface IRepository<T> : IReadRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task AddAsync(params T[] entities);
        Task AddAsync(IEnumerable<T> entities);


        Task DeleteAsync(T entity);
        Task DeleteAsync(object id);
        void Delete(params T[] entities);
        void Delete(IEnumerable<T> entities);


        void Update(T entity);
        void Update(params T[] entities);
        void Update(IEnumerable<T> entities);
    }
}
