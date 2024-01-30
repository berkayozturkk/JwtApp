namespace JwtApp.Core.Domain;

public class AppUser : Entity
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string AppRoleId { get; set; }

    public AppRole? AppRole { get; set; }

    public AppUser() {}

    public AppUser(string id,string userName, string password,
        string appRoleId) : base(id)
    {
        UserName = userName;
        Password = password;
        AppRoleId = appRoleId;
    }
}
