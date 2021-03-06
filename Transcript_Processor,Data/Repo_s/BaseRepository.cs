using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Transcript_Processor_Data.Interfaces;
using Transcript_Processor_Data.Repo_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Transcript_Processor_Data.Repo_s

{
    //public class BaseRepository<T> : IBaseRepository<T> where T : class
    //{
    //    protected readonly AppDbContext _context;
    //    private readonly DbSet<T> _dbset;
    //    public BaseRepository(AppDbContext context)
    //    {
    //        this._context = context;
    //        this._dbset = _context.Set<T>();
    //    }

    //    public T Add(T Entity)
    //    {
    //        var bb = _dbset.Add(Entity);
    //       return bb.Entity;
    //    }

    //    public T Exist(Expression<Func<T, bool>> Args)
    //    {
    //        var qury = _dbset.AsQueryable();
    //        var Entity = qury.Where(Args).FirstOrDefault();
    //        return Entity;
    //    }

    //    public IEnumerable<T> FindAll(Expression<Func<T, bool>> Args)
    //    {
    //        var qury = _dbset.AsQueryable();
    //        var Entity =  qury.Where(Args).ToList();
    //        return Entity;
    //    }
    //    public T Find(Expression<Func<T, bool>> Args)
    //    {
    //        var qury = _dbset.AsQueryable();
    //        var Entity = qury.Where(Args).FirstOrDefault();
    //        return Entity;
    //    }

    //    public IEnumerable<T>  GetAll()
    //    {
    //        var qury = _dbset.AsQueryable();
    //        var Entity = qury.ToList();
    //        return Entity;
    //    }

    //    public T GetbyId(int Id)
    //    {
    //      var Entity=  _dbset.Find(Id);
    //        return Entity;
    //    }

    //    public void Remove(int id)
    //    {
    //        var Entity = _dbset.Find(id);
    //         _dbset.Remove(Entity);
    //    }

    //    public T Update(T Entity)
    //    {
    //      var UpdatedEntity =  _dbset.Update(Entity);
    //        return UpdatedEntity.Entity;
    //    }

    //}
    public abstract class BaseRepository<T> : IReadRepository<T> where T : class
    {
        protected readonly ProcessorContext
 _dbContext;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ProcessorContext
 context)
        {
            _dbContext = context ?? throw new ArgumentException(nameof(context));
            _dbSet = _dbContext.Set<T>();
        }


        //public virtual IQueryable<T> Query(string sql, params object[] parameters) => _dbSet.FromSql(sql, parameters);

        public T Search(params object[] keyValues) => _dbSet.Find(keyValues);

        public async Task<T> SearchAsync(params object[] keyValues) => await _dbSet.FindAsync(keyValues);

        public T Single(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true)
        {

            IQueryable<T> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            var result = query.SingleOrDefault(predicate);
            return result;

        }

        public async Task<T> SingleAsync(Expression<Func<T, bool>> predicate,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
          bool disableTracking = true)
        {

            IQueryable<T> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            var result = await query.SingleOrDefaultAsync(predicate);
            return result;

        }
        public T JustSingle(Expression<Func<T, bool>> predicate,
  Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
  bool disableTracking = true)
        {

            IQueryable<T> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            var result = query.SingleOrDefault(predicate);
            return result;

        }

        public T First(Expression<Func<T, bool>> predicate = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
           bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query).FirstOrDefault();
            return query.FirstOrDefault();
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> predicate = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
          bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).FirstOrDefaultAsync();
            return await query.FirstOrDefaultAsync();
        }


        public T Last(Expression<Func<T, bool>> predicate = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
          bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query).LastOrDefault();
            return query.LastOrDefault();
        }

        public async Task<T> LastAsync(Expression<Func<T, bool>> predicate = null,
         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
         bool disableTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).LastOrDefaultAsync();
            return await query.LastOrDefaultAsync();
        }

        //IEnumerable<T> IReadRepository<T>.GetList(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>> include, bool disableTracking)
        //{
        //    IQueryable<T> query = _dbSet;
        //    if (disableTracking) query = query.AsNoTracking();

        //    if (include != null) query = include(query);

        //    if (predicate != null) query = query.Where(predicate);

        //    return orderBy != null
        //        ? orderBy(query).ToList()
        //        : query.ToList();
        //}

        async Task<IEnumerable<T>> IReadRepository<T>.GetListAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>> include, bool disableTracking)
        {

            IQueryable<T> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            return orderBy != null
                ? await orderBy(query).ToListAsync()
                : await query.ToListAsync();
        }

        IEnumerable<T> IReadRepository<T>.GetAll(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>> include, bool disableTracking)
        {

            IQueryable<T> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            return orderBy != null
                ? orderBy(query).ToList()
                : query.ToList();
        }
        IQueryable<T> IReadRepository<T>.GetQueryableList(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>> include, bool disableTracking)
        {
            IQueryable<T> query = _dbSet;
            if (disableTracking) query = query.AsNoTracking();

            if (include != null) query = include(query);

            if (predicate != null) query = query.Where(predicate);

            return orderBy != null
                ? orderBy(query)
                : query;
        }
    }
}
