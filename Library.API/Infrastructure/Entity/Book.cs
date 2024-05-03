namespace Library.API.Infrastructure.Entity
{
    public record Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public DateTime Published { get; set; }
        public string Publisher { get; set; }
        public virtual Author Author { get; set; }
    }
}
