using LibraryApi.Models;

namespace LibraryApi.Extensions;

public static class LoanExtensions
{
    public static Loan? CreateMemberFromDTO(this CreateLoanDTO loanDTO, AppDbContext db)
    {
        var member = db.Members.Find(loanDTO.MemberId);
        var book = db.Books.Find(loanDTO.BookId);

        if(member == null || book == null)
        {
            return null;
        }

        book.IsLoaned = true;

        return new Loan
        {
            Member = member,
            Book = book,
            LoanDate = DateOnly.FromDateTime(DateTime.Now)
        };
    }

    public static void ReturnBook(Loan loan)
    {
        loan.ReturnDate = DateOnly.FromDateTime(DateTime.Now);
        loan.Book.IsLoaned = false;
    }
}
