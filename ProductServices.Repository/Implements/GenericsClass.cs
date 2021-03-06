using Microsoft.EntityFrameworkCore;
using ProductServices.DTO;
using ProductServices.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Repository.Implements
{
    public class GenericsClass<T> : IGenericsClass<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenericsClass(IUnitOfWork unitOfWork) => (_unitOfWork) = (unitOfWork);
        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            var result = await _unitOfWork.Context.Set<T>().Where(expression).FirstOrDefaultAsync();
            return result;
        }
        public async Task<IEnumerable<T>> Get(Pagination pagination)
        {
            var result = await _unitOfWork.Context.Set<T>()
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
            return result;
        }
        public async Task Add(T entity) => await _unitOfWork.Context.AddAsync(entity);
        public async Task Delete(T entity)
        {
            _unitOfWork.Context.Set<T>().Remove(entity);
            await Task.CompletedTask;
        }
        public async Task Update(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }
    }
}
