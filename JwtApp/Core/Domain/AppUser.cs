namespace JwtApp.Core.Domain;

public class AppUser : Entity
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string AppRoleId { get; set; }

    public AppRole? AppRole { get; set; }

    public AppUser() {}
}
