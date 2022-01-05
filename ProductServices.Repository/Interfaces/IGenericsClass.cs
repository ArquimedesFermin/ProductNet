using ProductServices.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Repository.Interfaces
{
    public interface IGenericsClass<T> where T : class
    {
        Task<IEnumerable<T>> Get(Pagination pagination);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression, Pagination pagination);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
