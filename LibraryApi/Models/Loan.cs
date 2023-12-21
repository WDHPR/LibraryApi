namespace LibraryApi.Models;

public class Loan
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    public int BookId { get; set; }
    public DateOnly LoanDate { get; set; }
    public DateOnly? returnDate { get; set; }
}
