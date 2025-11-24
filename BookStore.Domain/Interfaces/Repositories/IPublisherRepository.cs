using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces.Repositories
{
    public interface IPublisherRepository
    {
        Task<Publisher> GetByIdAsync(Guid id);
        Task AddAsync(Publisher author);
        Task UpdateAsync(Publisher author);
        Task RemoveAsync(Publisher author);
    }
}
