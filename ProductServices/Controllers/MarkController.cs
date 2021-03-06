using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductServices.DTO;
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
        private readonly IMark _mark;

        public MarkController(IUnitOfWork unitOfWork, IGenericsClass<Marks> genericsClass,IMark mark) => (_unitOfWork, _genericsClass,_mark) = (unitOfWork, genericsClass,mark);

        [HttpGet]
        public async Task<Response> Get([FromQuery]Pagination pagination)
        {
            try
            {
                var marks = await _genericsClass.Get(pagination);

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                    Result = marks
                };
            }
            catch (System.Exception ex)
            {

                return new Response()
                {
                    StatusCode = 500,
                    IsOk = false,
                    Result = ex.Message
                };
            }
        }

        [HttpGet("{id}")]
        public async Task<Response> GetbyId([FromQuery]int id)
        {
            try
            {
                var mark = await _genericsClass.Get(x => x.Id == id);

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                    Result = mark
                };
            }
            catch (System.Exception ex)
            {
                return new Response()
                {
                    StatusCode = 500,
                    IsOk = false,
                    Result = ex.Message
                };
            }
        }

        [HttpPost]
        public async Task<Response> Add([FromBody] Marks marks)
        {
            try
            {
                await _genericsClass.Add(marks);
                _unitOfWork.Commit();

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                };
            }
            catch (System.Exception ex)
            {

                return new Response()
                {
                    StatusCode = 500,
                    IsOk = false,
                    Result = ex.Message
                };
            }
        }

        [HttpPut]
        public async Task<Response> Update([FromBody] Marks marks)
        {
            try
            {
                await _genericsClass.Update(marks);
                _unitOfWork.Commit();

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                };
            }
            catch (System.Exception ex)
            {
                return new Response()
                {
                    StatusCode = 500,
                    IsOk = false,
                    Result = ex.Message
                };
            }
        }

        [HttpDelete("{id}")]
        public async Task<Response> Delete(int id)
        {
            try
            {
                var mark = _unitOfWork.Context.marks.Find(id);
                await _genericsClass.Delete(mark);
                _unitOfWork.Commit();

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                };
            }
            catch (System.Exception ex)
            {
                return new Response()
                {
                    StatusCode = 500,
                    IsOk = false,
                    Result = ex.Message
                };
            }
        }

        [HttpGet("GetAllMark")]
        public async Task<Response> GetAll()
        {
            try
            { 
               var result = await _mark.GetAll();
                _unitOfWork.Commit();

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                    Result= result
                };
            }
            catch (System.Exception ex)
            {
                return new Response()
                {
                    StatusCode = 500,
                    IsOk = false,
                    Result = ex.Message
                };
            }
        }
    }
}
