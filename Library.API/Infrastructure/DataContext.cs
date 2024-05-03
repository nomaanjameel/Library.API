using Library.API.Infrastructure.Entity;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Library.API.Infrastructure
{
    public class DataContext
    {
        public List<Author> Authors { get; set; } = new List<Author>();
        public List<Book> Books { get; set; } = new List<Book>();

        public DataContext()
        {
            Books = Enumerable.Range(0, 5).Select(e => new Book
            {
                Title = $"Book {e}",
                Id = e,
                ISBN = "123456789",
                Published = DateTime.Now.AddYears(-e),
                Publisher = $"Publisher P{e}",
            }).ToList();

            Authors = new List<Author>
            {
                new Author
                {
                    Id = 1,
                    Name    = "Zak Bagens",
                },
                new Author
                {
                    Id = 2,
                    Name = "Nick Groff",
                },
            };

            Books[0].Author = Authors[0];
            Books[1].Author = Authors[1];
            Books[2].Author = Authors[1];
            Books[3].Author = Authors[0];
            Books[4].Author = Authors[1];
        }
    }
}
