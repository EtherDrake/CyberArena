using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CyberArena.Repository
{
    public interface IGenericRepository<T> where T: class
    {
        List<T> GetAll();
        List<T> FindBy(Expression<Func<T, bool>> predicate);
        T Get(int id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
