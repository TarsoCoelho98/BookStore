using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(Guid id);
        Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid authorId);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task RemoveAsync(Book book);
    }
}
