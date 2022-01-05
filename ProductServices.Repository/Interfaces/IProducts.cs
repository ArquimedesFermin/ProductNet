﻿using ProductServices.DTO;
using ProductServices.DTO.Product;
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
        Task<List<ProductsDTO>> Get(Pagination pagination);
        Task<IEnumerable<ProductsDTO>> Get(Expression<Func<Models.Products, bool>> expression);
        Task<DetailsPriceDTO> GetPriceByColor(string color);
        Task Add(ProductsDTO product);
        Task Update(ProductsDTO product);
        Task Delete(Products product);
    }
}
