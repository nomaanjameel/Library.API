using Library.API.Domain;
using Library.API.Infrastructure.Repository;
using Library.API.Models.Request;
using Library.API.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILogger<LibraryController> _logger;
        private readonly BookRepository _bookRepository;

        public LibraryController(
            ILogger<LibraryController> logger,
            BookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// Searches for a book by title.
        /// </summary>
        /// <remarks>
        /// Provide a book title, or partial match to return matching books.
        /// </remarks>
        /// <param name="title">The title of the book to search for</param>
        /// <returns>A collection BookSearchResult</returns>
        /// <response code="200">Returns matching books by title</response>
        /// <response code="400">When title parameter is not provided</response>
        /// <response code="404">When no books match the search title</response>
        [HttpGet("search/{title}")]
        [ProducesResponseType<IEnumerable<BookSearchResult>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<BookSearchResult>>> Search(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return BadRequest();
            }

            var results = await _bookRepository.Search(title);

            if (results.Any() == false)
            {
                return NotFound();
            }

            return Ok(results);
        }

        /// <summary>
        /// Adds a new book to the Library
        /// </summary>
        /// <param name="addBookRequest">The book to add</param>
        /// <returns>200 if successful</returns>
        /// <remarks code="400">When AddBookRequest is invalid or book already exists</remarks>
        [HttpPost("add")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Add([FromBody] AddBookRequest addBookRequest)
        {
            var existing = await _bookRepository.Search(addBookRequest.Title);
            if (existing.Any())
            {
                return BadRequest("Book already exists");
            }

            try
            {
                await _bookRepository.Add(addBookRequest);
            }
            catch (Exception ex)
            {
                StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }


        // Other typical Library functions...

        public async Task<ActionResult<LoanResponse>> Loan([FromBody] LoanRequest loanRequest)
        {
            return Ok();
        }

        public async Task<ActionResult<RenewResponse>> Renew([FromBody] RenewRequest renewRequest)
        {
            return Ok();
        }

        public async Task<ActionResult<ReservationResponse>> Reserve([FromBody] ReservationRequest reservationRequest)
        {
            return Ok();
        }

        public ActionResult MemberDetails(string membershipNumber)
        {
            // return Ok(_memberRepository.Get(membershipNumber));
            return Ok();
        }

        public ActionResult PayFine(string membershipNumber, decimal amount)
        {
            return Ok();
        }

        public async Task<ActionResult> Return(string memebershipNumber, string isbn)
        {
            // Calculate late fee


            // Mark as returned and available for loan


            return Ok();
        }

        // Good example of using Decorator pattern to update book values
        public ActionResult Categorise(string isbn, string category = "Young Adult Fiction")
        {
            var book = _bookRepository.FindByISBN(isbn);
            var youngAdultBookDecorator = new YoungAdultBookDecorator(book);
            youngAdultBookDecorator.SetCategory();

            _bookRepository.UpdateCategory(book);

            return Ok();
        }
    }
}
