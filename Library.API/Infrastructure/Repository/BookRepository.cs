using Library.API.Domain;
using Library.API.Infrastructure.Entity;
using Library.API.Models.Request;
using Library.API.Models.Response;

namespace Library.API.Infrastructure.Repository
{
    public class BookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookSearchResult>> Search(string title)
        {
            return await Task.FromResult(
            _context.Books.Select(b => new BookSearchResult
            {
                Title = b.Title,
                Author = b.Author.Name,
                ISBN = b.ISBN,
                Published = b.Published,
            }).Where(b => b.Title.Contains(title)));
        }

        public async Task Add(AddBookRequest addBookRequest)
        {
            var author = _context.Authors.First(a => a.Name == addBookRequest.Author);

            await new Task(() => _context.Books.Add(new Book
            {
                ISBN = addBookRequest.ISBN,
                Published = addBookRequest.Published,
                Publisher = addBookRequest.Publisher,
                Title = addBookRequest.Title,
                Author = author,
            }));
        }

        public ABook FindByISBN(string isbn)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(ABook book)
        {
            throw new NotImplementedException();
        }
    }
}
