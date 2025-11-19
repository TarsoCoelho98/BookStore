using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    internal class AuthorRepository : IAuthorRepository
    {
        private readonly AppContext _db;
        public AuthorRepository(AppContext db) => _db = db;

        public async Task<Author> GetByIdAsync(Guid id) =>
            await _db.Authors.FirstOrDefaultAsync(b => b.Id == id);

        public async Task AddAsync(Author author)
        {
            await _db.Authors.AddAsync(author);
        }

        public void Remove(Author author)
        {
            _db.Authors.Remove(author);
        }

        public void Update(Author author)
        {
            _db.Authors.Update(author);
        }
    }
}
