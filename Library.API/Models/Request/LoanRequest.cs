namespace Library.API.Models.Request
{
    public class LoanRequest : LoanDetailsBase
    {
        public DateTime LoanDate { get; set; }
    }
}
