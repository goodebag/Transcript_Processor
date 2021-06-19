
using Microsoft.EntityFrameworkCore;
using Processor_s_Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoUni_Report.Core.Repo_s
{
    public class UnitofWork<TContext> : IRepositoryFactory, IUnitofWork<TContext>
       where TContext : ProcessorContext
    {
        private Dictionary<Type, object> _repositories;

        public UnitofWork(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<TEntity>(Context);
            return (IRepository<TEntity>)_repositories[type];
        }



        public IRepositoryReadOnly<TEntity> GetReadOnlyRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new RepositoryReadOnly<TEntity>(Context);
            return (IRepositoryReadOnly<TEntity>)_repositories[type];
        }

        public TContext Context { get; }

        public void Dispose()
        {
            Context?.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            Task<int> saveChanges = Context.SaveChangesAsync();
            return await saveChanges;
        }
    }
}
