namespace JwtApp.Core.Domain;

public class AppRole : Entity
{
    public string Definition { get; set; }

    public List<AppUser> AppUsers { get; set; }

    public AppRole()
    {
        AppUsers = new List<AppUser>();
    }
}


