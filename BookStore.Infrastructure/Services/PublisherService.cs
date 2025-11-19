using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;

namespace BookStore.Infrastructure.Services
{
    internal class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        public PublisherService(IPublisherRepository publisherRepository) => _publisherRepository = publisherRepository;

        public async Task<Publisher> GetByIdAsync(Guid id) =>
            await _publisherRepository.GetByIdAsync(id);

        public async Task AddAsync(Publisher publisher)
        {
            await _publisherRepository.AddAsync(publisher);
        }

        public void Remove(Publisher publisher)
        {
            _publisherRepository.Remove(publisher);
        }

        public void Update(Publisher publisher)
        {
            _publisherRepository.Update(publisher);
        }
    }
}
