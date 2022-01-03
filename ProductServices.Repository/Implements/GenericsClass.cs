using Microsoft.EntityFrameworkCore;
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
        public GenericsClass(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression) => await _unitOfWork.Context.Set<T>().Where(expression).ToListAsync();
        public async Task<IEnumerable<T>> GetAll() => await _unitOfWork.Context.Set<T>().ToListAsync();
        public async Task Add(T entity) => await _unitOfWork.Context.AddAsync(entity);
        public async Task Remove(T entity)
        {
            T enti = await _unitOfWork.Context.Set<T>().FindAsync(entity);
            if (enti != null) _unitOfWork.Context.Set<T>().Remove(entity);
        }
        public async Task Update(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Context.Set<T>().Attach(entity);
            await Task.CompletedTask;
        }
    }
}
