namespace LibraryApi.Models;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public List<Book>? Books { get; set; }
}

public class CreateAuthorDTO
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int[]? BookIds { get; set; }
}