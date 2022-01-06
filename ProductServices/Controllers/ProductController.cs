using Microsoft.AspNetCore.Mvc;
using ProductServices.DTO;
using ProductServices.DTO.Product;
using ProductServices.Models;
using ProductServices.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProducts _productsImplements;

        public ProductController(IProducts productsImplements) => _productsImplements = productsImplements;

        [HttpGet]
        public async Task<Response> Get([FromQuery] Pagination pagination)
        {
            try
            {
                var products = await _productsImplements.Get(pagination);

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                    Result = products
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
        public async Task<IEnumerable<Products>> Get(int id)
        {
            return new List<Products>();
            //  return await _productsImplements.Get(x => x.Id == id);
        }

        [HttpPost]
        public async Task<Response> Post([FromBody] ProductsDTO products)
        {
            try
            {
                await _productsImplements.Add(products);
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

        [HttpPut("{id}")]
        public async Task<Response> Update(int id, [FromBody] ProductsDTO value)
        {
            try
            {
                await _productsImplements.Update(id, value);
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
                await _productsImplements.Delete(id);
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

        [HttpGet("GetDetailPriceByColor")]
        public async Task<Response> GetDetailPriceByColor([FromQuery] string color, string model)
        {
            try
            {
                var getResult = await _productsImplements.GetPriceByColor(color, model);

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                    Result = getResult
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

        [HttpGet("GetUpdate")]
        public async Task<Response> GetUpdate([FromQuery] int id)
        {
            try
            {
                var getResult = await _productsImplements.GetUpdate(x => x.Id == id);

                return new Response()
                {
                    StatusCode = 200,
                    IsOk = true,
                    Result = getResult
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
