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
                .Include(x => x.model).ThenInclude(x => x.Mark)
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
                    TypeProduct = x.productType.Name
                }).ToListAsync();
        }
        public async Task<IEnumerable<ProductsDTO>> Get(Expression<Func<Models.Products, bool>> expression)
        {
            return await _UnitOfWork.Context.products
                         .Include(x => x.model).ThenInclude(x => x.Mark)
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
                             TypeProduct = x.productType.Name
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
        public async Task Delete(int id)
        {
            var result = await _UnitOfWork.Context.products.Where(x => x.Id == id).FirstOrDefaultAsync();
            _UnitOfWork.Context.Remove(result);
            _UnitOfWork.Commit();
            await Task.CompletedTask;
        }
        public async Task Update(int Id, ProductsDTO products)
        {
            var productModelColorPrice = new ProductModelColorPrice();
            var ModelColorPrice = new ModelColorPrice();
            var product = new Models.Products();

            var color = _UnitOfWork.Context.colors.FirstOrDefault(x => x.Name == products.Color);
            var model = _UnitOfWork.Context.models.FirstOrDefault(x => x.Name == products.Model);
            var productType = _UnitOfWork.Context.productTypes.FirstOrDefault(x => x.Name == products.TypeProduct);
            var ProductModelColorPrice = _UnitOfWork.Context.productModelColorPrice.Where(x => x.IdProducts == Id).FirstOrDefault().IdModelColorPrice;
            var modelColorPrice = _UnitOfWork.Context.modelColorPrice.FirstOrDefault(x=>x.Id == ProductModelColorPrice);
            product = _UnitOfWork.Context.products.Where(x => x.Id == Id).FirstOrDefault();

            //Actualizar producto
            product.IdModel = model.Id;
            product.Name = products.Name;
            product.Description = products.Description;
            product.IdProductType = productType.Id;

            _UnitOfWork.Context.Entry(product).State = EntityState.Modified;
            _UnitOfWork.Commit();
            await Task.CompletedTask;
            productModelColorPrice.IdProducts = product.Id;

            //Actualizar ModelColorPrice
            ModelColorPrice = new ModelColorPrice()
            {
                IdModel = model.Id,
                IdColor = color.Id,
                Price = products.Price,
                Stock = (modelColorPrice is null) ? products.Stock : modelColorPrice.Stock + products.Stock,
            };


            modelColorPrice.IdModel = model.Id;
            modelColorPrice.IdColor = color.Id;
            modelColorPrice.Price = products.Price;
            modelColorPrice.Stock = products.Stock;

            _UnitOfWork.Context.Entry(modelColorPrice).State = EntityState.Modified;
            _UnitOfWork.Commit();

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
        public async Task<ProductsDTO> GetUpdate(Expression<Func<Models.Products, bool>> expression)
        {
            var result = await _UnitOfWork.Context.products
                        .Include(x => x.model)
                        .Include(x => x.productType)
                        .Include(x => x.model.modelColorPrice).ThenInclude(x => x.model)
                        .Include(x => x.model.modelColorPrice).ThenInclude(x => x.color)
                        .Include(x => x.productModelColorPrices).ThenInclude(x => x.ModelColorPrice)
                        .Where(expression)
                        .Select(x => new ProductsDTO()
                        {
                            Id = x.Id,
                            Color = x.productModelColorPrices.Where(a => a.IdProducts == x.Id).FirstOrDefault().ModelColorPrice.color.Name,
                            Price = x.productModelColorPrices.Where(a => a.IdProducts == x.Id).FirstOrDefault().ModelColorPrice.Price,
                            Stock = x.productModelColorPrices.Where(a => a.IdProducts == x.Id).First().ModelColorPrice.Stock,
                            Model = x.model.Name,
                            Name = x.Name,
                            Description = x.Description,
                            TypeProduct = x.productType.Name
                        }).FirstOrDefaultAsync();


            return result;
        }  
    }
}