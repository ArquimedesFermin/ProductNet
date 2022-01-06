using Microsoft.EntityFrameworkCore;
using ProductServices.DTO.Color;
using ProductServices.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Repository.Implements
{
    public class Color : IColor
    {
        private readonly IUnitOfWork _UnitOfWork;
        public Color(IUnitOfWork UnitOfWork) => (_UnitOfWork) = UnitOfWork;
        public async Task<List<ColorDTO>> GetColor()
        {
            var result = await _UnitOfWork.Context.colors.Select(x => new ColorDTO()
            {
                Id = x.Id,
                NameColor = x.Name,
                HexColor = x.HexColor,
            }).ToListAsync();

            return result;
        }
    }
}
