using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet("author/{authorId:guid}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetByAuthorId(Guid authorId)
        {
            var books = await _bookService.GetByAuthorIdAsync(authorId);

            if (!books.Any())
                return NotFound("Nenhum livro encontrado para este autor.");

            return Ok(books);
        }

        [HttpGet("book/{id:guid}")]
        public async Task<ActionResult<Book>> GetById(Guid id)
        {
            var book = await _bookService.GetByIdAsync(id);

            if (book == null)
                return NotFound("Nenhum livro encontrado para este id.");

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Add(Book book)
        {
            await _bookService.AddAsync(book);

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Book updated)
        {
            var existing = await _bookService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.Title = updated.Title;
            existing.Genre = updated.Genre;
            existing.PublicationDate = updated.PublicationDate;
            
            _bookService.Update(existing);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await _bookService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            _bookService.Remove(existing);

            return NoContent();
        }
    }
}
