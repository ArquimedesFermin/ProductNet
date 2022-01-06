using Microsoft.EntityFrameworkCore;
using ProductServices.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Repository.Implements
{
    public class ProductType : IProductType
    {
        private readonly IUnitOfWork _UnitOfWork;
        public ProductType(IUnitOfWork UnitOfWork) => (_UnitOfWork) = UnitOfWork;
        public async Task<List<Models.ProductType>> GetProductTypeAll()
        {
              return await _UnitOfWork.Context.productTypes.ToListAsync(); 
        }
    }
}
