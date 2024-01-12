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

public class AuthorDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<MinimalBookDTO>? Books { get; set; }
}

//DTO with minimal information for use with BookDTO
public class MinimalAuthorDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}