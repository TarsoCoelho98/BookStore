using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author> GetByIdAsync(Guid id);
        Task AddAsync(Author author);
        void Update(Author author);
        void Remove(Author author);
    }
}
