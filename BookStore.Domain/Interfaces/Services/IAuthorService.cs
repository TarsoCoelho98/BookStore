using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<Author> GetByIdAsync(Guid id);
        Task AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task RemoveAsync(Author author);
    }
}
