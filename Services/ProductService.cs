using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace curso_blazor_webassembly;

public class ProductService: IProductService
{
    private readonly HttpClient client;
    private readonly JsonSerializerOptions options;

    public ProductService(HttpClient httpClient)
    {
        client = httpClient;
        options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<List<Product>?> Get()
    {
        var response = await client.GetAsync("api/v1/products");
        var content = await response.Content.ReadAsStringAsync();
        if(!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        // return await JsonSerializer.DeserializeAsync<List<Product>>(await response.Content.ReadAsStreamAsync(), options);
        List<Product> productos = JsonSerializer.Deserialize<List<Product>>(content , options);
    productos?.ForEach(producto =>
    {
        int cantidad = producto.Images.Count();
        string[] imagenes = new string[cantidad];
        int i = 0;
        foreach (var images in producto.Images)
        {
            imagenes[i] = images.ToString().Replace("\"", "").Replace("]", "").Replace("[", "");
            i++;
        }

        producto.Images = imagenes;
    }); 

    return productos;
    }
    public async Task Add(Product product)
    {
        var response = await client.PostAsync("api/v1/products",JsonContent.Create(product));
        var Content = await response.Content.ReadAsStringAsync();
        if(!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(Content);
        }
    }
    public async Task Delete(int productId)
    {
        var response = await client.DeleteAsync($"api/v1/products/{productId}");
        var Content = await response.Content.ReadAsStringAsync();
        if(!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(Content);
        }
    }
}
public interface IProductService
{
    Task<List<Product>?> Get();

    Task Add(Product product);

    Task Delete(int productId);
}