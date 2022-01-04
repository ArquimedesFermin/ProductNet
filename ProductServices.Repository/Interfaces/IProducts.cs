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
        Task<List<ProductsDTO>> Get();
        Task<IEnumerable<ProductsDTO>> Get(Expression<Func<Models.Products, bool>> expression);
        Task Add(ProductsDTO product);
        Task Update(ProductsDTO product);
        Task Delete(Products product);
    }
}
