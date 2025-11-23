using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublisherController : ControllerBase
    {
        private readonly ILogger<PublisherController> _logger;
        private readonly IPublisherService _publisherService;

        public PublisherController(ILogger<PublisherController> logger, IPublisherService publisherService)
        {
            _logger = logger;
            _publisherService = publisherService;
        }

        [HttpGet("publisher/{id:guid}")]
        public async Task<ActionResult<Publisher>> GetById(Guid id)
        {
            var publisher = await _publisherService.GetByIdAsync(id);

            if (publisher == null)
                return NotFound("Nenhuma editora encontrada para este id.");

            return Ok(publisher);
        }

        [HttpPost]
        public async Task<ActionResult<Publisher>> Add(Publisher publisher)
        {
            await _publisherService.AddAsync(publisher);

            return CreatedAtAction(nameof(GetById), new { id = publisher.Id }, publisher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Publisher updated)
        {
            var existing = await _publisherService.GetByIdAsync(id);
            
            if (existing == null)
                return NotFound();

            existing.Name = updated.Name;
            existing.Country = updated.Country;
            existing.Adress = updated.Adress;

            _publisherService.Update(existing);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await _publisherService.GetByIdAsync(id);
            
            if (existing == null)
                return NotFound();

            _publisherService.Remove(existing);

            return NoContent();
        }
    }
}
