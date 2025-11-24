using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStore.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDbContext _db;
        public AuthorRepository(BookStoreDbContext db) => _db = db;

        public async Task<Author> GetByIdAsync(Guid id) =>
            await _db.Authors.FirstOrDefaultAsync(b => b.Id == id);

        public async Task AddAsync(Author author)
        {
            await _db.Authors.AddAsync(author);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveAsync(Author author)
        {
            _db.Authors.Remove(author);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            _db.Authors.Update(author);
            await _db.SaveChangesAsync();
        }
    }
}
