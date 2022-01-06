using Microsoft.EntityFrameworkCore;
using ProductServices.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Repository.Implements
{
    public class Model : IModel
    {
        private readonly IUnitOfWork _UnitOfWork;
        public Model(IUnitOfWork UnitOfWork) => (_UnitOfWork) = UnitOfWork;

        public async Task<List<Models.Models>> GetModelAll()
        {
            return await _UnitOfWork.Context.models.ToListAsync();
        }
    }
}
