using ProductServices.DTO.Color;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Repository.Interfaces
{
    public interface IColor
    {
        Task<List<ColorDTO>> GetColor();
    }
}
