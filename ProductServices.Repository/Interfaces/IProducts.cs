using ProductServices.DTO;
using ProductServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Repository.Interfaces
{
    public interface IProducts
    {
        Task<IEnumerable<Products>> Get();
        Task<IEnumerable<Products>> Get(Expression<Func<Products, bool>> expression);
        Task Add(ProductsDTO product);
        Task Update(Products product);
        Task Delete(Products product);
    }
}
