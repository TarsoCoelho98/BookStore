using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;

namespace BookStore.Infrastructure.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository) => _authorRepository = authorRepository;

        public async Task<Author> GetByIdAsync(Guid id) =>
            await _authorRepository.GetByIdAsync(id);

        public async Task AddAsync(Author author)
        {
            await _authorRepository.AddAsync(author);
        }

        public async Task RemoveAsync(Author author)
        {
            await _authorRepository.RemoveAsync(author);
        }

        public async Task UpdateAsync(Author author)
        {
            await _authorRepository.UpdateAsync(author);
        }
    }
}
