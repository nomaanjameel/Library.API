namespace Library.API.Models.Response
{
    public class LoanResponse : LoanDetailsBase
    {
        public string Id { get; set; }
        public DateTime DueDate { get; set; }
        public decimal LateFee { get; set; }
    }
}
