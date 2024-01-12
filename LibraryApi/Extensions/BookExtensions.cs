using LibraryApi.Models;

namespace LibraryApi.Extensions;

public static class BookExtensions
{
    public static Book CreateBookFromDTO(this CreateBookDTO bookDTO, AppDbContext db)
    {
        var published = new DateOnly(bookDTO.PublishedYear, 1, 1);
        var authors = new List<Author>();
                
        foreach (var id in bookDTO.AuthorIds)
        {
            authors.Add(db.Authors.First(a => a.Id == id));
        }    

        return new Book
        {
            Title = bookDTO.Title,
            Isbn = bookDTO.Isbn,
            Authors = authors,
            Published = published
        };
    }
}
