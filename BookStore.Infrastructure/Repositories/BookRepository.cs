using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _db;
        public BookRepository(BookStoreDbContext db) => _db = db;

        public async Task<Book> GetByIdAsync(Guid id) =>
            await _db.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);

        public async Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid authorId) =>
            await _db.Books.Where(b => b.AuthorId == authorId).ToListAsync();

        public async Task AddAsync(Book book)
        {
            if (book.Author != null && book.Author.Id != Guid.Empty)
                _db.Attach(book.Author); 

            if (book.Publisher != null && book.Publisher.Id != Guid.Empty)
                _db.Attach(book.Publisher);

            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _db.Books.Update(book);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveAsync(Book book)
        {
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
        }
    }
}
