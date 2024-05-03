namespace Library.API.Models.Response
{
    public class RenewResponse : LoanDetailsBase
    {
        public bool CanRenew { get; set; }
        public DateTime DueDate { get; set; }
    }
}
