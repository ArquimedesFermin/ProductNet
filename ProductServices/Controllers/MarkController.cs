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
    public class MarkController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericsClass<Marks> _genericsClass;

        public MarkController(IUnitOfWork unitOfWork, IGenericsClass<Marks> genericsClass) => (_unitOfWork, _genericsClass) = (unitOfWork, genericsClass);

        [HttpGet]
        public async Task<IEnumerable<Marks>> Get() => await _genericsClass.Get();

        [HttpGet("{id}")]
        public async Task<IEnumerable<Marks>> GetbyId(int id) => await _genericsClass.Get(x => x.Id == id);

        [HttpPost]
        public void Add([FromBody] Marks mark)
        {
            _genericsClass.Add(mark);
            _unitOfWork.Commit();
        }

        [HttpPut]
        public async Task Update(Marks mark)
        {
            await _genericsClass.Update(mark);
            _unitOfWork.Commit();
        }

        [HttpDelete]
        public async Task Delete(Marks mark)
        {
            await _genericsClass.Delete(mark);
            _unitOfWork.Commit();
        }
    }
}
