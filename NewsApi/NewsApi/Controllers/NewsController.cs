using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Application.Services;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase 
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string title, string content, string source, string author, int categoryId)
        {
            var result = await _newsService.Create(title, content, source, author, categoryId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var result = await _newsService.GetById(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _newsService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, string title, string content, string source,
            string author,
            int categoryId)
        {
            var result = await _newsService.Update(id, title, content, source, author, categoryId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string title, int? categoryId)
        {
            var result = await _newsService.Get(title, categoryId);
            return Ok(result);
        }

    }
}
