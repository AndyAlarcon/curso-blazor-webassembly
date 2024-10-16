namespace curso_blazor_webassembly;

public class Product
{
    public int Id {get;set; }
    public string Title {get;set;}
    public double? Price {get;set;}
    public string Description {get;set;}
    public int CategoryId {get;set;}
    public [] string Images {get;set;}
    public string? Image {get;set;}
}