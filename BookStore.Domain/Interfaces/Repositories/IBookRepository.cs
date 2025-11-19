using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(Guid id);
        Task<IEnumerable<Book>> GetByAuthorIdAsync(Guid authorId);
        Task AddAsync(Book book);
        void Update(Book book);
        void Remove(Book book);
    }
}
