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
            var products = await _productsImplements.Get();


            return new Response()
            {
                StatusCode = 200,
                IsOk = true,
                Result = products
            };
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Products>> Get(int id)
        {
            return new List<Products>();
            //  return await _productsImplements.Get(x => x.Id == id);
        }

        [HttpPost]
        public async Task Post([FromBody] ProductsDTO products)
        {
            await _productsImplements.Add(products);
        }

        [HttpPut("{id}")]
        public async Task Update([FromBody] Products value)
        {
            //  await _productsImplements.Update(value);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Products products)
        {
            await _productsImplements.Delete(products);
        }
    }
}
