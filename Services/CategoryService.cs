using System.Text.Json;

namespace curso_blazor_webassembly;

public class CategoryService: ICategoryService
{
     private readonly HttpClient client;
    private readonly JsonSerializerOptions options;

    public CategoryService(HttpClient httpClient)
    {
        client = httpClient;
        options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }
    public async Task<List<Category>?> Get()
    {
        var response = await client.GetAsync("/v1/categories");
        var content = await response.Content.ReadAsStringAsync();
        if(!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        return await JsonSerializer.DeserializeAsync<List<Category>>(await response.Content.ReadAsStreamAsync(), options);
    }
}
public interface ICategoryService
{
    Task<List<Category>?> Get();
}