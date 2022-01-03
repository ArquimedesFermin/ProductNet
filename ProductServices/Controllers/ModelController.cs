using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductServices.Repository;
using ProductServices.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericsClass<Models.Models> _genericsClass;

        public ModelController(IUnitOfWork unitOfWork, IGenericsClass<Models.Models> genericsClass) => (_unitOfWork, _genericsClass) = (unitOfWork, genericsClass);

        [HttpGet]
        public async Task<IEnumerable<Models.Models>> Get() => await _genericsClass.Get();

        [HttpGet("{id}")]
        public async Task<IEnumerable<Models.Models>> GetbyId(int id) => await _genericsClass.Get(x => x.Id == id);

        [HttpPost]
        public void Add([FromBody] Models.Models model)
        {
            _genericsClass.Add(model);
            _unitOfWork.Commit();
        }

        [HttpPut]
        public async Task Update(Models.Models model)
        {
            await _genericsClass.Update(model);
            _unitOfWork.Commit();
        }

        [HttpDelete]
        public async Task Delete(Models.Models model)
        {
            await _genericsClass.Delete(model);
            _unitOfWork.Commit();
        }
    }
}
