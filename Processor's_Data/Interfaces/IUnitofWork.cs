using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Processor_s_Data.Interfaces
{
    interface IUnitofWork
    {
        public interface IUnitOfWork : IDisposable
        {
            Task Save();
        }
        public interface IUnitofWork : IDisposable
        {
            IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
            Task<int> SaveChangesAsync();
        }
        public interface IUnitofWork<TContext> : IUnitofWork where TContext : DbContext
        {
            TContext Context { get; }
        }
    }
}
