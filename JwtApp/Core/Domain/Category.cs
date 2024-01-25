namespace JwtApp.Core.Domain;

public class Category : Entity
{
    public string Name { get; set; }

    public List<Product> Products { get; set; }

    public Category()
    {
        Products = new List<Product>();
    }
}


