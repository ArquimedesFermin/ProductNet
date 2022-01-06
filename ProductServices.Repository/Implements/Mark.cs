using Microsoft.EntityFrameworkCore;
using ProductServices.Models;
using ProductServices.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Repository.Implements
{
    public class Mark : IMark
    {
        private readonly IUnitOfWork _UnitOfWork;
        public Mark(IUnitOfWork UnitOfWork) => (_UnitOfWork) = UnitOfWork;

        public async Task<List<Marks>> GetAll()
        {
            return await _UnitOfWork.Context.marks.ToListAsync();

        }
    }
}
