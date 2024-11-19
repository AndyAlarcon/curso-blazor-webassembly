namespace curso_blazor_webassembly;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int? Price { get; set; }
    public string Description { get; set; }
    public string [] Images { get; set; }
    public DateTime CreationAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public string Image { get;set; }
}