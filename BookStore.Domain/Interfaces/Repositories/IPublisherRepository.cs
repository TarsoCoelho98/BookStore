using BookStore.Domain.Entities;

namespace BookStore.Domain.Interfaces.Repositories
{
    public interface IPublisherRepository
    {
        Task<Publisher> GetByIdAsync(Guid id);
        Task AddAsync(Publisher author);
        void Update(Publisher author);
        void Remove(Publisher author);
    }
}
