using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    internal class PublisherRepository : IPublisherRepository
    {
        private readonly AppContext _db;
        public PublisherRepository(AppContext db) => _db = db;

        public async Task<Publisher> GetByIdAsync(Guid id) =>
            await _db.Publishers.FirstOrDefaultAsync(b => b.Id == id);

        public async Task AddAsync(Publisher publisher)
        {
            await _db.Publishers.AddAsync(publisher);
        }

        public void Remove(Publisher publisher)
        {
            _db.Publishers.Remove(publisher);
        }

        public void Update(Publisher publisher)
        {
            _db.Publishers.Update(publisher);
        }
    }
}
