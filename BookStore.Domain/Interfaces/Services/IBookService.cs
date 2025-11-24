using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces.Services
{
    public interface IBookService
    {
        Task<Book> GetByIdAsync(Guid id);
        Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid authorId);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task RemoveAsync(Book book);
    }
}
