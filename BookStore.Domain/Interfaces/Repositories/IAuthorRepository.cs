using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author> GetByIdAsync(Guid id);
        Task AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task RemoveAsync(Author author);
    }
}
