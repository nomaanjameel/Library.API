using System.ComponentModel.DataAnnotations;
using Library.API.Validation;

namespace Library.API.Models.Request
{
    public class AddBookRequest
    {
        [Required(ErrorMessage = "Book title is required")]
        [MinLength(6)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        public string Author {  get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$")]
        public string ISBN { get; set; }

        [Required]
        [MinLength(5)]
        public string Publisher { get; set; }

        [MustBeInPast]
        public DateTime Published { get; set; }
    }
}
