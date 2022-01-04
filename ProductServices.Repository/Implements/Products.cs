using Microsoft.EntityFrameworkCore;
using ProductServices.Context;
using ProductServices.DTO;
using ProductServices.Models;
using ProductServices.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Repository.Implements
{
    public class Products : IProducts
    {
        private readonly IUnitOfWork _UnitOfWork;
        public Products(IUnitOfWork UnitOfWork) => (_UnitOfWork) = UnitOfWork;

        public async Task<IEnumerable<ProductsDTO>> Get()
        {
            //return await _UnitOfWork.Context.products
            //    .Include(x => x.mark).ThenInclude(x => x.model)
            //    .Include(x => x.productColors).ThenInclude(x => x.products)
            //    .Include(x => x.productColors).ThenInclude(x => x.color)
            //    .Select( x=> new ProductsDTO() {
            //        Marck =x.mark.Name,
            //        Model = x.mark.model.Name,
            //        Name = x.Name,
            //        Stock = x.Stock,
            //        Comments = x.Comments,
            //        Price = x.productColors.Where(x=>x.)


            //    });
            //    .ToListAsync();

            return new List<ProductsDTO>();

          
        }

        public async Task<IEnumerable<ProductsDTO>> Get(Expression<Func<Models.Products, bool>> expression)
        {
            //return await _UnitOfWork.Context.products.Where(expression).ToListAsync();

            return new List<ProductsDTO>();

        }

        public async Task Add(ProductsDTO products)
        {
            var color = _UnitOfWork.Context.colors.FirstOrDefault(x => x.Name == products.Color);
            var model = _UnitOfWork.Context.models.FirstOrDefault(x => x.Name == products.Model);
            var mark = _UnitOfWork.Context.marks.FirstOrDefault(x => x.Name == products.Marck);
            var productType = _UnitOfWork.Context.productTypes.FirstOrDefault(x => x.Name == products.TypeProduct);

            var product = new Models.Products()
            {
                IdModel = model.Id,
                Name = products.Name,
                Stock = products.Stock,
                Comments = products.Comments,
                DateManufacture = products.DateManufacture,
                IdProductType = productType.Id
            };

            await _UnitOfWork.Context.AddAsync(product);
            _UnitOfWork.Commit();

            var ProductColor = new MarkColor()
            {
                IdMarks = mark.Id,
                IdColor = color.Id,
                Price = products.Price
            };

            _UnitOfWork.Context.marksColor.Add(ProductColor);
            _UnitOfWork.Commit();
        }

        public async Task Delete(Models.Products product)
        {
            _UnitOfWork.Context.Remove(product);
            _UnitOfWork.Commit();
            await Task.CompletedTask;
        }
        public async Task Update(ProductsDTO product)
        {
            _UnitOfWork.Context.Entry(product).State = EntityState.Modified;
            _UnitOfWork.Commit();
            await Task.CompletedTask;
        }
    }
}
