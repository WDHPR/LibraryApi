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

    public static BookDTO BookToDTO(this Book book)
    {
        return new BookDTO
        {
            Id = book.Id,
            Isbn = book.Isbn,
            Title = book.Title,
            Authors = book.Authors?.Select(a => a.AuthorToMinimalDTO()).ToList(),
            PublishedYear = (short)book.Published.Year,
            IsLoaned = book.IsLoaned
        };
    }

    public static MinimalBookDTO BookToMinimalDTO(this Book book)
    {
        return new MinimalBookDTO
        {
            Id = book.Id,
            Title = book.Title
        };
    }
}
