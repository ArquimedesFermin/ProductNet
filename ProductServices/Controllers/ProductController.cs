using Microsoft.AspNetCore.Mvc;
using ProductServices.DTO;
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
        public async Task<Response> Get()
        {


            try
            {
                var products = await _productsImplements.Get();

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
        public async Task Update([FromBody] Products value)
        {
            //  await _productsImplements.Update(value);
        }

        [HttpDelete]
        public async Task Delete(Products products)
        {
            await _productsImplements.Delete(products);
        }
    }
}
