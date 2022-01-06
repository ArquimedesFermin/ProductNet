using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductServices.DTO;
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
        private readonly IModel _model;
        public ModelController(IUnitOfWork unitOfWork, IGenericsClass<Models.Models> genericsClass, IModel model) => (_unitOfWork, _genericsClass,_model) = (unitOfWork, genericsClass,model);

        [HttpGet]
        public async Task<Response> Get(Pagination pagination)
        {
            try
            {
                var models = await _genericsClass.Get(pagination);

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                    Result = models
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
        public async Task<Response> GetbyId(int id, Pagination pagination)
        {
            try
            {
                var model = await _genericsClass.Get(x => x.Id == id, pagination);

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                    Result = model
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
        public async Task<Response> Add([FromBody] Models.Models models)
        {
            try
            {
                await _genericsClass.Add(models);
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
        public async Task<Response> Update([FromBody] Models.Models models)
        {
            try
            {
                await _genericsClass.Update(models);
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
                var model = _unitOfWork.Context.models.Find(id);
                await _genericsClass.Delete(model);
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

        [HttpGet("GetModelAll")]
        public async Task<Response> GetModelAll()
        {
            try
            {
                var models = await _model.GetModelAll();

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                    Result = models
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
