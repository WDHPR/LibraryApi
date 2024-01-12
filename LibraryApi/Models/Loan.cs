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

public class LoanDTO
{
    public int Id { get; set; }
    public MemberDTO Member { get; set; } = null!;
    public MinimalBookDTO Book { get; set; } = null!;
    public string LoanDate { get; set; } = null!;
    public string? ReturnDate { get; set; }
}