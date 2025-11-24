using System.Text.Json.Serialization;

namespace BookStore.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public Guid PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public string Genre { get; set; }
    }
}
