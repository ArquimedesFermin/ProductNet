using ProductServices.DTO;
using ProductServices.DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Repository.Interfaces
{
    public interface IModel
    {
        Task<List<Models.Models>> GetModelAll();
        Task<List<ModelDTO>> GetModelGrid(Pagination pagination);
        
    }
}
