namespace LibraryApi.Models;

public class Book
{
    public int Id { get; set; }
    public int Isbn { get; set; }
    public string? Title { get; set; }
    public List<Author> Authors { get; set; }
    // bool for loan status? maybe unnecessary
}
