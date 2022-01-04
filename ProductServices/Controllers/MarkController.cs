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

        public MarkController(IUnitOfWork unitOfWork, IGenericsClass<Marks> genericsClass) => (_unitOfWork, _genericsClass) = (unitOfWork, genericsClass);

        public async Task<Response> Get()
        {
            try
            {
                var productType = await _genericsClass.Get();

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                    Result = productType
                };
            }
            catch (System.Exception ex)
            {

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                    Result = ex.Message
                };
            }
        }

        [HttpGet("{id}")]
        public async Task<Response> GetbyId(int id)
        {
            try
            {
                var productType = await _genericsClass.Get(x => x.Id == id);

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                    Result = productType
                };
            }
            catch (System.Exception ex)
            {
                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
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
                    StatusCode = 200,
                    IsOk = true,
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
                    StatusCode = 200,
                    IsOk = true,
                    Result = ex.Message
                };
            }
        }

        [HttpDelete]
        public async Task<Response> Delete([FromBody] Marks marks)
        {
            try
            {
                await _genericsClass.Delete(marks);
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
                    StatusCode = 200,
                    IsOk = true,
                    Result = ex.Message
                };
            }
        }
    }
}
