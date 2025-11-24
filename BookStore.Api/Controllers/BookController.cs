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
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;

        public BookController(ILogger<BookController> logger, IBookService bookService, IPublisherService publisherService, IAuthorService authorService)
        {
            _logger = logger;
            _bookService = bookService;
            _publisherService = publisherService;
            _authorService = authorService;
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
            var author = await _authorService.GetByIdAsync(book.AuthorId);

            if (author is null)
                return NotFound("Nenhum autor encontrado com esse Id.");
            else
                book.Author = author;

            var publisher = await _publisherService.GetByIdAsync(book.PublisherId);

            if (publisher is null)
                return NotFound("Nenhuma editora encontrada com esse Id.");
            else
                book.Publisher = publisher;

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

            _bookService.UpdateAsync(existing);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await _bookService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            _bookService.RemoveAsync(existing);

            return NoContent();
        }
    }
}
