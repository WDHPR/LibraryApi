using LibraryApi.Models;

namespace LibraryApi.Extensions;

public static class AuthorExtensions
{

    public static Author CreateAuthorFromDTO(this CreateAuthorDTO authorDTO, AppDbContext db)
    {
        var books = new List<Book>();
        if(authorDTO.BookIds != null)
        {
            foreach(var id in authorDTO.BookIds)
            {
                books.Add(db.Books.First(b => b.Id == id));
            }
        }
        return new Author
        {
            FirstName = authorDTO.FirstName,
            LastName = authorDTO.LastName,
            Books = books
        };
    }

    public static AuthorDTO AuthorToDTO(this Author author)
    {
        return new AuthorDTO
        {
            Id = author.Id,
            Name = $"{author.FirstName} {author.LastName}",
            Books = author.Books?.Select(b => b.BookToMinimalDTO()).ToList()
        };
    }

    public static MinimalAuthorDTO AuthorToMinimalDTO(this Author author)
    {
        return new MinimalAuthorDTO
        {
            Id = author.Id,
            Name = $"{author.FirstName} {author.LastName}"
        };
    }
}
