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
    public class ProductTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericsClass<ProductType> _genericsClass;
        private readonly IProductType _productType;

        public ProductTypeController(IUnitOfWork unitOfWork, IGenericsClass<ProductType> genericsClass, IProductType productType) => (_unitOfWork, _genericsClass, _productType) = (unitOfWork, genericsClass, productType);

        [HttpGet]
        public async Task<Response> Get([FromQuery] Pagination pagination)
        {
            try
            {
                var productType = await _genericsClass.Get(pagination);

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
        public async Task<Response> GetbyId([FromQuery] int id)
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
        public async Task<Response> Add([FromBody] ProductType productType)
        {
            try
            {
                await _genericsClass.Add(productType);
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
        public async Task<Response> Update([FromBody] ProductType productType)
        {
            try
            {
                await _genericsClass.Update(productType);
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
        public async Task<Response> Delete([FromQuery] int id)
        {
            try
            {
                var result = _unitOfWork.Context.productTypes.Find(id);
                await _genericsClass.Delete(result);
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

        [HttpGet("GetProductoTypeAll")]
        public async Task<Response> GetProductoTypeAll()
        {
            try
            {
                var productType = await _productType.GetProductTypeAll();

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
    }
}
