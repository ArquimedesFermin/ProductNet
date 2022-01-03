using ProductServices.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        void Commit();
        ProductContext Context { get; }
    }
}
