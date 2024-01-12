namespace LibraryApi.Models;

public class Member
{
    public int Id { get; set; }
    public int MemberNr { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}

public class CreateMemberDTO
{
    public int MemberNr { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}

public class MemberDTO
{
    public int Id { get; set; }
    public int MemberNr { get; set; }
    public string Name { get; set; } = null!;
}
