using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;

namespace BookStore.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository) => _bookRepository = bookRepository;

        public async Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid authorId)
        {
            return await _bookRepository.GetByAuthorIdAsync(authorId);
        }
        public async Task<Book> GetByIdAsync(Guid id) =>
            await _bookRepository.GetByIdAsync(id);

        public async Task AddAsync(Book book)
        {
            await _bookRepository.AddAsync(book);
        }

        public async Task RemoveAsync(Book book)
        {
            await _bookRepository.RemoveAsync(book);
        }

        public async Task UpdateAsync(Book book)
        {
            await _bookRepository.UpdateAsync(book);
        }
    }
}
