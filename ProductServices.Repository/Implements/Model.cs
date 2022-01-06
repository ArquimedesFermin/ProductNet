using Microsoft.EntityFrameworkCore;
using ProductServices.DTO;
using ProductServices.DTO.Model;
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

        public async Task<List<ModelDTO>> GetModelGrid(Pagination pagination)
        {
            return await _UnitOfWork.Context.models
                .Include(x => x.Mark)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(x => new ModelDTO
                {
                    Id = x.Id,
                    Model = x.Name,
                    Marca = x.Mark.Name
                })
                .ToListAsync();
        }
    }
}
