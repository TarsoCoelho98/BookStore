using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces.Services
{
    public interface IPublisherService
    {
        Task<Publisher> GetByIdAsync(Guid id);
        Task AddAsync(Publisher author);
        Task UpdateAsync(Publisher author);
        Task RemoveAsync(Publisher author);
    }
}
