namespace LibraryApi.Models;

public class Author
{
    public int Id { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public List<Book>? Books { get; set; }
}
