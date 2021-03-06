using Microsoft.EntityFrameworkCore;
using ProductServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {

        }
        public DbSet<Marks> marks { get; set; }
        public DbSet<Models.Models> models { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Color> colors { get; set; }
        public DbSet<ModelColorPrice> modelColorPrice { get; set; }
        public DbSet<ProductModelColorPrice> productModelColorPrice { get; set; }
        public DbSet<ProductType> productTypes { get; set; }
    }
}
