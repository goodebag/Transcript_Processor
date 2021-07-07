using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Transcript_Processor_Data.Interfaces;
using Transcript_Processor_Data.Repo_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoUni_Report.Core.Repo_s
{
    public class Repository<T> : BaseRepository<T>, IRepository<T> where T : class
    {
        public Repository(ProcessorContext
 context) : base(context)
        {
        }

        public async Task<T> AddAsync(T entity)
        {
            EntityEntry<T> taskToAdd = await _dbSet.AddAsync(entity);
            return taskToAdd.Entity;
        }
        public async Task AddAsync(params T[] entities)
        {
            Task addTask = _dbSet.AddRangeAsync(entities);
            await addTask;
        }
        public async Task AddAsync(IEnumerable<T> entities)
        {
            Task taskToAdd = _dbSet.AddRangeAsync(entities);
            await taskToAdd;
        }


        public async Task DeleteAsync(T entity)
        {
            T existing = await _dbSet.FindAsync(entity);
            T existingEntity = existing;
            if (existingEntity != null)
            {
                _dbSet.Remove(existingEntity);
            }
        }


        public async Task DeleteAsync(object id)
        {
            TypeInfo typeInfo = typeof(T).GetTypeInfo();
            IProperty key = _dbContext.Model.FindEntityType(typeInfo).FindPrimaryKey().Properties.FirstOrDefault();
            PropertyInfo property = typeInfo.GetProperty(key?.Name);
            if (property != null)
            {
                T entity = Activator.CreateInstance<T>();
                property.SetValue(entity, id);
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            else
            {
                T taskEntity = await _dbSet.FindAsync(id);
                T entity = taskEntity;
                if (entity != null)
                {
                    Delete(entity);
                }
            }
        }

        public void Delete(params T[] entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Update(params T[] entities)
        {
            _dbSet.UpdateRange(entities);
        }


        public void Update(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }
    }
}
