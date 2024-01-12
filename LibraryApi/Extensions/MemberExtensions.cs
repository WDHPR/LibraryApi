using LibraryApi.Models;

namespace LibraryApi.Extensions;

public static class MemberExtensions
{
    public static Member CreateMemberFromDTO(this CreateMemberDTO memberDTO)
    {
        return new Member
        {
            MemberNr = memberDTO.MemberNr,
            FirstName = memberDTO.FirstName,
            LastName = memberDTO.LastName
        };
    }

    public static MemberDTO MemberToDTO(this Member member)
    {
        return new MemberDTO
        {
            Id = member.Id,
            MemberNr = member.MemberNr,
            Name = $"{member.FirstName} {member.LastName}"
        };
    }
}
