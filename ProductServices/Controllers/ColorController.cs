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
        public async Task<Response> Get([FromQuery] Pagination pagination)
        {
            try
            {
                var colors = await _genericsClass.Get(pagination);

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                    Result = colors
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

        [HttpGet("{name}")]
        public async Task<Response> GetbyId(string name,[FromQuery] Pagination pagination)
        {
            try
            {
                var color = await _genericsClass.Get(x => x.Name == name, pagination);

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                    Result = color
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
                    StatusCode = 500,
                    IsOk = false,
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
                var color = await _unitOfWork.Context.colors.FindAsync(id);
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
                    StatusCode = 500,
                    IsOk = false,
                    Result = ex.Message
                };
            }
        }
    }
}
