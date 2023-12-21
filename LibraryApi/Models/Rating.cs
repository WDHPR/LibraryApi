namespace LibraryApi.Models;

public class Rating
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    public int BookId { get; set; }
    public int RatingValue { get; set; }
    public string? Comment { get; set; }
}