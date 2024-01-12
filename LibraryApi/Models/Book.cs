namespace LibraryApi.Models;

public class Book
{
    public int Id { get; set; }
    public string Isbn { get; set; } = null!;
    public string Title { get; set; } = null!;
    public List<Author> Authors { get; set; } = null!;
    public DateOnly Published { get; set; }
    public bool IsLoaned { get; set; } = false;
}

public class CreateBookDTO
{
    public string Isbn { get; set; } = null!;
    public string Title { get; set; } = null!;
    public int PublishedYear { get; set; }
    public int[] AuthorIds { get; set; } = null!;
}

public class BookDTO
{
    public int Id { get; set; }
    public string Isbn { get; set; } = null!;
    public string Title { get; set; } = null!;
    public List<MinimalAuthorDTO>? Authors { get; set; }
    public short PublishedYear { get; set; }
    public bool IsLoaned { get; set; } = false;
}

//DTO with minimal information for use with AuthorDTO
public class MinimalBookDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
}