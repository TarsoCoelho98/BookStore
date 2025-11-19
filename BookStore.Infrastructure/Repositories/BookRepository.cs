using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    internal class BookRepository : IBookRepository
    {
        private readonly AppContext _db;
        public BookRepository(AppContext db) => _db = db;

        public async Task<Book> GetByIdAsync(Guid id) =>
            await _db.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);

        public async Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid authorId) =>
            await _db.Books.Where(b => b.AuthorId == authorId).ToListAsync();

        public async Task AddAsync(Book book)
        {
            await _db.Books.AddAsync(book);
        }

        public void Update(Book book)
        {
            _db.Books.Update(book);
        }

        public void Remove(Book book)
        {
            _db.Books.Remove(book);
        }
    }
}
