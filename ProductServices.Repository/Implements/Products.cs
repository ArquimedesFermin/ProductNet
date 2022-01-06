using Microsoft.EntityFrameworkCore;
using ProductServices.Context;
using ProductServices.DTO;
using ProductServices.DTO.Product;
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
        public async Task<List<ProductsDTO>> Get(Pagination pagination)
        {
            return await _UnitOfWork.Context.products
                .Include(x => x.model).ThenInclude(x => x.Mark).ThenInclude(x => x.ProductType)
                .Include(x => x.model.modelColorPrice).ThenInclude(x => x.model)
                .Include(x => x.model.modelColorPrice).ThenInclude(x => x.color)
                .Include(x => x.productModelColorPrices)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(x => new ProductsDTO()
                {
                    Id = x.Id,
                    Marks = x.model.Mark.Name,
                    Model = x.model.Name,
                    Name = x.Name,
                    Description = x.Description,
                    TypeProduct = x.productType.Name,
                    Price = x.productModelColorPrices.Where(x => x.IdProducts == x.IdProducts).First().ModelColorPrice.Price,
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
                             Id = x.Id,
                             Marks = x.model.Mark.Name,
                             Model = x.model.Name,
                             Name = x.Name,
                             Description = x.Description,
                             TypeProduct = x.productType.Name,
                             Price = x.productModelColorPrices.Where(x => x.IdProducts == x.IdProducts).First().ModelColorPrice.Price,
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
                Description = products.Description,
                IdProductType = productType.Id,

            };

            await _UnitOfWork.Context.AddAsync(product);
            _UnitOfWork.Commit();
            productModelColorPrice.IdProducts = product.Id;

            ModelColorPrice = new ModelColorPrice()
            {
                IdModel = model.Id,
                IdColor = color.Id,
                Price = products.Price,
                Stock = (modelColorPrice is null) ? products.Stock : modelColorPrice.Stock + products.Stock,
            };

            if (modelColorPrice is null)
            {
                _UnitOfWork.Context.modelColorPrice.Add(ModelColorPrice);
                _UnitOfWork.Commit();
            }
            else
            {
                modelColorPrice.Stock = (modelColorPrice is null) ? products.Stock : modelColorPrice.Stock + products.Stock;
                _UnitOfWork.Context.Entry(modelColorPrice).State = EntityState.Modified;
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
        public async Task<DetailsPriceDTO> GetPriceByColor(string color, string model)
        {
            var colorObj = _UnitOfWork.Context.colors.Where(x => x.Name == color).FirstOrDefault();
            var modelObj = _UnitOfWork.Context.models.Where(x => x.Name == model).FirstOrDefault();

            var DatailPrice = await _UnitOfWork.Context.modelColorPrice
                 .Include(x => x.color)
                 .Where(a => a.IdColor == colorObj.Id && a.IdModel == modelObj.Id)
                 .Select(x => new DetailsPriceDTO()
                 {
                     Price = x.Price,
                     Stock = x.Stock,
                     Color = x.color.Name,
                     ColorHex = x.color.HexColor
                 }).FirstOrDefaultAsync();

            return DatailPrice;
        }
    }
}
