using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;

namespace BookStore.Infrastructure.Services
{
    internal class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository) => _authorRepository = authorRepository;

        public async Task<Author> GetByIdAsync(Guid id) =>
            await _authorRepository.GetByIdAsync(id);

        public async Task AddAsync(Author author)
        {
            await _authorRepository.AddAsync(author);
        }

        public void Remove(Author author)
        {
            _authorRepository.Remove(author);
        }

        public void Update(Author author)
        {
            _authorRepository.Update(author);
        }
    }
}
