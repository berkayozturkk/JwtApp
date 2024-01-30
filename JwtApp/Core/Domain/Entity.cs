namespace JwtApp.Core.Domain;

public class Entity
{
    public string Id { get; set; }

    public Entity() {}

    public Entity(string id)
    {
        Id = id;
    }
}


