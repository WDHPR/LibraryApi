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
                // Add error handling in case book doesn't exist
                // Or move this part to the controller as async
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
}
