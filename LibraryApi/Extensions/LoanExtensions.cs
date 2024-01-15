using LibraryApi.Models;

namespace LibraryApi.Extensions;

public static class LoanExtensions
{
    public static Loan? CreateLoanFromDTO(this CreateLoanDTO loanDTO, AppDbContext db)
    {
        var member = db.Members.Find(loanDTO.MemberId);
        var book = db.Books.Find(loanDTO.BookId);

        if (member == null || book == null || book.IsLoaned)
            return null;

        book.IsLoaned = true;

        return new Loan
        {
            Member = member,
            Book = book,
            LoanDate = DateOnly.FromDateTime(DateTime.Now)
        };
    }

    public static LoanDTO LoanToDTO(this Loan loan)
    {
        return new LoanDTO
        {
            Id = loan.Id,
            Member = loan.Member.MemberToDTO(),
            Book = loan.Book.BookToMinimalDTO(),
            LoanDate = loan.LoanDate.ToString("yyyy-MM-dd"),
            ReturnDate = loan.ReturnDate?.ToString("yyyy-MM-dd")
        };
    }

    public static void EndLoan(this Loan loan)
    {
        loan.ReturnDate = DateOnly.FromDateTime(DateTime.Now);
        loan.Book.IsLoaned = false;
    }
}
