using ProductServices.Models;
using ProductServices.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Repository.Interfaces
{
    public interface IMark
    {
        Task<List<Marks>> GetAll();
    }
}
