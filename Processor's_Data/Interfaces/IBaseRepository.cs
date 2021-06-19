using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Processor_s_Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetbyId(int Id);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindAll(Expression<Func<T, bool>> Args);
        T Find(Expression<Func<T, bool>> Args);
        T Add(T Entity);
        void Remove(int id);
        T Update(T Entity);
        T Exist(Expression<Func<T, bool>> Args);
    }
}
