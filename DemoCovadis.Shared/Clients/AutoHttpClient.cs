using DemoCovadis.Shared.Dtos;
using System.Text.Json;

namespace DemoCovadis.Shared.Clients;

public class AutoHttpClient
{
    private readonly HttpClient client;
    private readonly JsonSerializerOptions jsonOptions;

    public AutoHttpClient(IHttpClientFactory httpClientFactory)
    {
        client = httpClientFactory.CreateClient(nameof(AutoHttpClient));
        client.BaseAddress = new Uri("http://localhost:5077/Auto");

        jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<AutoDto[]> GetAutos()
    {
        var response = await client.GetAsync(string.Empty);

        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        var content = await response.Content.ReadAsStringAsync();
        var autos = JsonSerializer.Deserialize<AutoDto[]>(content, jsonOptions);

        if (autos is null)
        {
            return [];
        }

        return autos;
    }
}
