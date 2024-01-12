using LibraryApi.Models;

namespace LibraryApi.Extensions;

public static class RatingExtensions
{
    public static Rating? CreateRatingFromDTO(this CreateRatingDTO ratingDTO, AppDbContext db)
    {
        var member = db.Members.Find(ratingDTO.MemberId);
        var book = db.Books.Find(ratingDTO.BookId);

        if (member == null || book == null)
        {
            return null;
        }

        return new Rating
        {
            Member = member,
            Book = book,
            RatingValue = ratingDTO.RatingValue,
            Comment = ratingDTO.Comment
        };
    }

    public static RatingDTO RatingToDTO(this Rating rating)
    {
        return new RatingDTO
        {
            Id = rating.Id,
            Member = rating.Member.MemberToDTO(),
            Book = rating.Book.BookToMinimalDTO(),
            RatingValue = rating.RatingValue,
            Comment = rating.Comment
        };
    }
}
