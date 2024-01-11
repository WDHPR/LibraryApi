namespace LibraryApi.Models;

public class Book
{
    public int Id { get; set; }
    public int Isbn { get; set; }
    public string Title { get; set; } = null!;
    public List<Author>? Authors { get; set; }
    public DateOnly Published { get; set; }
    public bool IsLoaned { get; set; } = false;
}

public class CreateBookDTO
{
    public int Isbn { get; set; }
    public string Title { get; set; } = null!;
    public int PublishedYear { get; set; }
    public int[]? AuthorIds { get; set; }
}
