using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductServices.Models;
using ProductServices.Repository;
using ProductServices.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericsClass<Color> _genericsClass;

        public ColorController(IUnitOfWork unitOfWork, IGenericsClass<Color> genericsClass) => (_unitOfWork, _genericsClass) = (unitOfWork, genericsClass);

        [HttpGet]
        public async Task<IEnumerable<Color>> Get() => await _genericsClass.Get();

        [HttpGet("{id}")]
        public async Task<IEnumerable<Color>> GetbyId(int id) => await _genericsClass.Get(x => x.Id == id);

        [HttpPost]
        public void Add([FromBody] Color mark)
        {
            _genericsClass.Add(mark);
            _unitOfWork.Commit();
        }

        [HttpPut]
        public async Task Update([FromBody] Color mark)
        {
            await _genericsClass.Update(mark);
            _unitOfWork.Commit();
        }

        [HttpDelete]
        public async Task Delete([FromBody] Color mark)
        {
            await _genericsClass.Delete(mark);
            _unitOfWork.Commit();
        }
    }
}
