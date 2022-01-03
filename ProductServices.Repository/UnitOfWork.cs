using ProductServices.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ProductContext Context { get; }
        public UnitOfWork(ProductContext context) => Context = context;
        public void Commit() => Context.SaveChanges(); 
        public void Dispose() => Context.Dispose();
    }
}
