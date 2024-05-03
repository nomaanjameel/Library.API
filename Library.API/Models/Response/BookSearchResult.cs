namespace Library.API.Models.Response
{
    public class BookSearchResult
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public DateTime Published { get; set; }
    }
}
