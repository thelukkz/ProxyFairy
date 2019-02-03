using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProxyFairy.Core.Model;
using ProxyFairy.Core.Repository.Abstract;

namespace ProxyFairy.Core.Repository.Concrete
{
    public class Repository : IRepository
    {
        AppIdentityDbContext _context;

        public Repository(IDbFactory dbFactory)
        {
            _context = dbFactory.GetDataContext;
        }

        public IQueryable<T> All<T>() where T : class
        {
            return _context.Set<T>().AsQueryable();
        }

        public virtual void Create<T>(T TObject) where T : class
        {
            var newEntry = _context.Set<T>().Add(TObject);
        }

        public void Delete<T>(T TObject) where T : class
        {
            _context.Set<T>().Remove(TObject);
        }

        public virtual void Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var objects = Filter<T>(predicate);
            _context.Set<T>().RemoveRange(objects);
        }

        public virtual void Update<T>(T TObject) where T : class
        {
            try
            {
                var entry = _context.Entry(TObject);
                _context.Set<T>().Attach(TObject);
                entry.State = EntityState.Modified;
            }
            catch(Exception ex)
            {
                //TODO add logs later
            }
        }

        public void ExecuteProcedure(string procedureCommand, params SqlParameter[] sqlParams)
        {
            _context.Database.ExecuteSqlCommand(procedureCommand, sqlParams);
        }

        public virtual IEnumerable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public virtual IEnumerable<T> Filter<T>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) where T : class
        {
            int skipCount = index * size;
            var _resetSet = filter != null
                ? _context.Set<T>().Where<T>(filter).AsQueryable()
                : _context.Set<T>().AsQueryable();
            _resetSet = skipCount == 0
                ? _resetSet.Take(size)
                : _resetSet.Skip(skipCount).Take(size);

            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public virtual T Find<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().FirstOrDefault<T>(predicate);
        }

        public async Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _context.Set<T>().FirstOrDefaultAsync<T>(predicate);
        }

        public T Single<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return All<T>().FirstOrDefault(expression);
        }

        public async Task<T> SingleAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await All<T>().FirstOrDefaultAsync(expression);
        }

        public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Count<T>(predicate) > 0;
        }

        public async Task<bool> ContainsAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _context.Set<T>().LongCountAsync<T>(predicate) > 0;
        }

        public long Count<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().LongCount<T>(predicate);
        }

        public async Task<long> CountAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _context.Set<T>().LongCountAsync<T>(predicate);
        }
    }
}
