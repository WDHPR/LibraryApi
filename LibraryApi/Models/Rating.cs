namespace LibraryApi.Models;

public class Rating
{
    public int Id { get; set; }
    public required Member Member { get; set; }
    public required Book Book { get; set; }
    public int RatingValue { get; set; }
    public string? Comment { get; set; }
}

public class CreateRatingDTO
{
    public int MemberId { get; set; }
    public int BookId { get; set; }
    public int RatingValue { get; set; }
    public string? Comment { get; set; }
}

public class RatingDTO
{
    public int Id { get; set; }
    public MemberDTO Member { get; set; } = null!;
    public MinimalBookDTO Book { get; set; } = null!;
    public int RatingValue { get; set; }
    public string? Comment { get; set; }
}