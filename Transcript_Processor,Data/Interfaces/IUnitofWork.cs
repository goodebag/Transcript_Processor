using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Transcript_Processor_Data.Interfaces
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
