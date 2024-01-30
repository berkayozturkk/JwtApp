namespace JwtApp.Core.Application.Dto;

public class CheckUserResponseDto
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string? Role { get; set; }
    public bool IsExist { get; set; }

    public CheckUserResponseDto() {}

    public CheckUserResponseDto(bool isExist)
    {
        IsExist = isExist;
    }

    public CheckUserResponseDto(string id, string username, bool isExist)
    {
        Id = id;
        Username = username;
        IsExist = isExist;
    }
}
