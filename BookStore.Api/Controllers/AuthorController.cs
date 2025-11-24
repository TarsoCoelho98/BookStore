using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorService _authorService;

        public AuthorController(ILogger<AuthorController> logger, IAuthorService authorService)
        {
            _logger = logger;
            _authorService = authorService;
        }

        [HttpGet("author/{id:guid}")]
        public async Task<ActionResult<Author>> GetById(Guid id)
        {
            var author = await _authorService.GetByIdAsync(id);

            if (author == null)
                return NotFound("Nenhum autor encontrado para este id.");

            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> Add(Author author)
        {
            await _authorService.AddAsync(author);
            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Author updated)
        {
            var existing = await _authorService.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            existing.Name = updated.Name;
            existing.Country = updated.Country;
            existing.Birthdate = updated.Birthdate;

            await _authorService.UpdateAsync(existing);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await _authorService.GetByIdAsync(id);

            if (existing == null)
                return NotFound();

            await _authorService.RemoveAsync(existing);

            return NoContent();
        }
    }
}
