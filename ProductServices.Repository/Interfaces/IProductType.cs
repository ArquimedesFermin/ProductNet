using ProductServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Repository.Interfaces
{
    public interface IProductType
    {
        Task<List<ProductType>> GetProductTypeAll();
    }
}
