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
        private readonly IUnitOfWork _context;
        public Products(IUnitOfWork context) => (_context) = context;

        public async Task<IEnumerable<Models.Products>> Get()
        {
            return await _context.Context.products.ToListAsync();
        }

        public async Task<IEnumerable<Models.Products>> Get(Expression<Func<Models.Products, bool>> expression)
        {
            return await _context.Context.products.Where(expression).ToListAsync();
        }

        public async Task Add(ProductsDTO products)
        {
            int IdMarks = 0, IdModel = 0, IdColor = 0;
            var color = _context.Context.colors.FirstOrDefault(x => x.Name == products.Color);
            var model = _context.Context.models.FirstOrDefault(x => x.Name == products.Model);
            var mark = _context.Context.marks.FirstOrDefault(x => x.Name == products.Marck);

            if (color is null)
            {
                var colorNew = new Color() { Name = products.Color };
                _context.Context.colors.Add(colorNew);
                _context.Commit();
                IdColor = _context.Context.colors.FirstOrDefault(x => x.Name == products.Color).Id;
            }

            if (mark is null)
            {
                if (model is null)
                {
                    var modelNew = new Models.Models() { Name = products.Model };
                    _context.Context.models.Add(modelNew);
                    _context.Commit();
                    IdModel = _context.Context.models.FirstOrDefault(x => x.Name == products.Model).Id;
                }
                var marksNew = new Marks() { Name = products.Marck };
                _context.Context.marks.Add(marksNew);
                _context.Commit();
                IdMarks = _context.Context.marks.FirstOrDefault(x => x.Name == products.Marck).Id;
            }

            var product = new Models.Products()
            {
                IdMark = IdMarks,
                Name = products.Name,
                Stock = products.Stock,
                Comments = products.Comments,
                DateManufacture = products.DateManufacture
            };

            await _context.Context.AddAsync(product);
            _context.Commit();

            var ProductColor = new ProductColor()
            {
                IdProduct = product.Id,
                IdColor = IdColor,
                Price = products.Price
            };

            _context.Context.productsColor.Add(ProductColor);
            _context.Commit();
        }






        public async Task Delete(Models.Products product)
        {
            _context.Context.Remove(product);
            _context.Commit();
            await Task.CompletedTask;
        }
        public async Task Update(Models.Products product)
        {
            _context.Context.Entry(product).State = EntityState.Modified;
            _context.Commit();
            await Task.CompletedTask;
        }
    }
}
