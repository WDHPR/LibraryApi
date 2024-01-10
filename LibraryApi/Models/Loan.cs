namespace LibraryApi.Models;

public class Loan
{
    public int Id { get; set; }
    public required Member Member { get; set; }
    public required Book Book { get; set; }
    public DateOnly LoanDate { get; set; }
    public DateOnly? ReturnDate { get; set; }
}

public class CreateLoanDTO
{
    public int MemberId { get; set; }
    public int BookId { get; set; }
}