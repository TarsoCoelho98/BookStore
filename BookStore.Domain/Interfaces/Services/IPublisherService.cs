using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces.Services
{
    public interface IPublisherService
    {
        Task<Publisher> GetByIdAsync(Guid id);
        Task AddAsync(Publisher author);
        void Update(Publisher author);
        void Remove(Publisher author);
    }
}
