using CatalogAPI.Entities;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        /// <summary>
        /// GET: api/<CategoryController>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Category>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCategories()
        {
            var products = await _categoryService.GetAll();
            return Ok(products);
        }

        /// <summary>
        /// POST api/<CategoryController>
        /// </summary>
        /// <param name="Category"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Category category)
        {
            await _categoryService.AddCategoryAsync(category);
            return CreatedAtRoute("GetProduct", new { id = category.Id }, category);
        }

        /// <summary>
        /// PUT api/<CategoryController>/5
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>

        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            return Ok(await _categoryService.UpdateCategoryAsync(category.Id, category));
        }

        /// <summary>
        /// DELETE api/<CategoryController>/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCategoryById(string id)
        {
            return Ok(await _categoryService.RemoveCategoryAsync(id));
        }
    }
}
