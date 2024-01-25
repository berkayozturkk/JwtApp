namespace JwtApp.Core.Domain;

public class Product : Entity
{
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public string CategoryId { get; set; }

    public Categoty Categoty { get; set; }

    public Product()
    {
        Categoty = new Categoty();
    }


}


