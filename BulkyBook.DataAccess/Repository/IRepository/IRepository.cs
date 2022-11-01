using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<T> GetAll (Expression<Func<T, bool>>? filter=null,string? includeProperties = null);
        IEnumerable<T> Get (int id);
        void Add(T entity);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties =null);
        void RemoveRange(IEnumerable<T> entity);
        public void Remove(T entity);
    }
}
