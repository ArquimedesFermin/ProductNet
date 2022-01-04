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
    public class ColorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericsClass<Color> _genericsClass;

        public ColorController(IUnitOfWork unitOfWork, IGenericsClass<Color> genericsClass) => (_unitOfWork, _genericsClass) = (unitOfWork, genericsClass);

        [HttpGet]
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
        public async Task<Response> Add([FromBody] Color color)
        {
            try
            {
                await _genericsClass.Add(color);
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
        public async Task<Response> Update([FromBody] Color color)
        {
            try
            {
                await _genericsClass.Update(color);
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
        public async Task<Response> Delete([FromBody] Color color)
        {
            try
            {
                await _genericsClass.Delete(color);
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
