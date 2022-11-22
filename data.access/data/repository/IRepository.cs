using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace data.access.data.repository
{
    public interface IRepository<T> where T : class
    {
        T get(int id);

        IEnumerable<T> getAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params string[] includeProperties
            );

        T getFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            params string[] includeProperties
            );

        void add(T entity);

        void remove(int id);

        void remove(T entity);




        Task<T> getByIdAsync(int id);

        Task<List<T>> getAllAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params string[] includeProperties
            );

        Task<T> getFirstOrDefaultAsync(
            Expression<Func<T, bool>> filter = null,
            params string[] includeProperties
            );

        Task<int> countAsync(Expression<Func<T, bool>> filter = null);

        Task<T> addAsync(T entity);
        Task<List<T>> addMassiveAsync(List<T> entities);
        Task<T> updateAsync(int id, T entity);
        Task<T> removeAsync(int id);

    }
}
