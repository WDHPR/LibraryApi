using LibraryApi.Models;

namespace LibraryApi.Extensions;

public static class LoanExtensions
{
    public static Loan? CreateLoanFromDTO(this CreateLoanDTO loanDTO, AppDbContext db)
    {
        var member = db.Members.Find(loanDTO.MemberId);
        var book = db.Books.Find(loanDTO.BookId);

        //Throw error if book is already loaned out

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

    public static void EndLoan(this Loan loan)
    {
        loan.ReturnDate = DateOnly.FromDateTime(DateTime.Now);
        loan.Book.IsLoaned = false;
    }
}
