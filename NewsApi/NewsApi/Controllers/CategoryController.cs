using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Application.Services;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            var result = await _categoryService.Create(name);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, string name)
        {
            var result = await _categoryService.Update(id, name);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string name)
        {
            await _categoryService.Delete(name);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result =  await _categoryService.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var result = await _categoryService.Get(name);
            return Ok(result);
        }
    }
}
