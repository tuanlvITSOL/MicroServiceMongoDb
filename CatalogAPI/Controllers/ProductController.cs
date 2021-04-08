using CatalogAPI.Entities;
using CatalogAPI.Repositories.Interfaces;
using CatalogAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        /// <summary>
        /// GET: api/<ProductController>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }

        /// <summary>
        /// /// GET api/<ProductController>/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                _logger.LogError($"Product with id: {id} was not found.");
                return NotFound();
            }
            return Ok(product);
        }
        /// <summary>
        /// GET: Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [Route("[action]/{category}")]
        [HttpGet]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            var product = await _productService.GetProductByCategory(category);
            return Ok(product);

        }

        /// <summary>
        /// POST api/<ProductController>
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            await _productService.AddProductAsync(product);
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }
        /// <summary>
        /// PUT api/<ProductController>/5
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            return Ok(await _productService.UpdateProductAsync(product.Id,product));
        }

        /// <summary>
        /// DELETE api/<ProductController>/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            return Ok(await _productService.RemoveProductAsync(id));
        }
    }
}
