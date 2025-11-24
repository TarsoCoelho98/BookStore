using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly BookStoreDbContext _db;
        public PublisherRepository(BookStoreDbContext db) => _db = db;

        public async Task<Publisher> GetByIdAsync(Guid id) =>
            await _db.Publishers.FirstOrDefaultAsync(b => b.Id == id);

        public async Task AddAsync(Publisher publisher)
        {
            await _db.Publishers.AddAsync(publisher);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveAsync(Publisher publisher)
        {
            _db.Publishers.Remove(publisher);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Publisher publisher)
        {
            _db.Publishers.Update(publisher);
            await _db.SaveChangesAsync();
        }
    }
}
