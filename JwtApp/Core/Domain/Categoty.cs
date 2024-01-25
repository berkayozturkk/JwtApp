namespace JwtApp.Core.Domain;

public class Categoty : Entity
{
    public string Name { get; set; }

    public List<Product> Products { get; set; }

    public Categoty()
    {
        Products = new List<Product>();
    }
}


