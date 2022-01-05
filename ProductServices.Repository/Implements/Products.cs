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
        public async Task<List<ProductsDTO>> Get()
        {
            return await _UnitOfWork.Context.products
                .Include(x => x.model).ThenInclude(x => x.Mark).ThenInclude(x => x.ProductType)
                .Include(x => x.model.modelColorPrice).ThenInclude(x => x.model)
                .Include(x => x.model.modelColorPrice).ThenInclude(x => x.color)
                .Include(x => x.productModelColorPrices)
                .Select(x => new ProductsDTO()
                {
                    Marks = x.model.Mark.Name,
                    Model = x.model.Name,
                    Name = x.Name,
                    Stock = x.Stock,
                    Description = x.Description,
                    TypeProduct = x.productType.Name,
                    Price = x.productModelColorPrices.Where(x => x.IdProducts == x.IdProducts).First().ModelColorPrice.Price,
                    Color = x.productModelColorPrices.Where(x => x.IdProducts == x.IdProducts).First().ModelColorPrice.color.Name
                }).ToListAsync();
        }

        public async Task<IEnumerable<ProductsDTO>> Get(Expression<Func<Models.Products, bool>> expression)
        {
            return await _UnitOfWork.Context.products
                         .Include(x => x.model).ThenInclude(x => x.Mark).ThenInclude(x => x.ProductType)
                         .Include(x => x.model.modelColorPrice).ThenInclude(x => x.model)
                         .Include(x => x.model.modelColorPrice).ThenInclude(x => x.color)
                         .Include(x => x.productModelColorPrices)
                         .Where(expression)
                         .Select(x => new ProductsDTO()
                         {
                             Marks = x.model.Mark.Name,
                             Model = x.model.Name,
                             Name = x.Name,
                             Stock = x.Stock,
                             Description = x.Description,
                             TypeProduct = x.productType.Name,
                             Price = x.productModelColorPrices.Where(x => x.IdProducts == x.IdProducts).First().ModelColorPrice.Price,
                             Color = x.productModelColorPrices.Where(x => x.IdProducts == x.IdProducts).First().ModelColorPrice.color.Name
                         }).ToListAsync();
        }

        public async Task Add(ProductsDTO products)
        {
            var productModelColorPrice = new ProductModelColorPrice();
            var ModelColorPrice = new ModelColorPrice();
            var product = new Models.Products();

            var color = _UnitOfWork.Context.colors.FirstOrDefault(x => x.Name == products.Color);
            var model = _UnitOfWork.Context.models.FirstOrDefault(x => x.Name == products.Model);
            var productType = _UnitOfWork.Context.productTypes.FirstOrDefault(x => x.Name == products.TypeProduct);
            var modelColorPrice = _UnitOfWork.Context.modelColorPrice.FirstOrDefault(x => x.IdModel == model.Id && x.IdColor == color.Id);

            product = new Models.Products()
            {
                IdModel = model.Id,
                Name = products.Name,
                Stock = products.Stock,
                Description = products.Description,
                IdProductType = productType.Id,

            };

            await _UnitOfWork.Context.AddAsync(product);
            _UnitOfWork.Commit();
            productModelColorPrice.IdProducts = product.Id;

            if (modelColorPrice is null)
            {
                ModelColorPrice = new ModelColorPrice()
                {
                    IdModel = model.Id,
                    IdColor = color.Id,
                    Price = products.Price,
                };
                _UnitOfWork.Context.modelColorPrice.Add(ModelColorPrice);
                _UnitOfWork.Commit();
            }
            productModelColorPrice.IdModelColorPrice = ModelColorPrice.Id == 0 ? modelColorPrice.Id : ModelColorPrice.Id;

            _UnitOfWork.Context.productModelColorPrice.Add(productModelColorPrice);
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
