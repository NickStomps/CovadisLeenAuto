using DemoCovadis.Shared.Dtos;
using System.Text.Json;

namespace DemoCovadis.Shared.Clients;

public class RitHttpClient
{
    private readonly HttpClient client;
    private readonly JsonSerializerOptions jsonOptions;

    public RitHttpClient(IHttpClientFactory httpClientFactory)
    {
        client = httpClientFactory.CreateClient(nameof(RitHttpClient));
        client.BaseAddress = new Uri("http://localhost:5077/Rit");

        jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<RitDto[]> GetRitten()
    {
        var response = await client.GetAsync(string.Empty);

        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        var content = await response.Content.ReadAsStringAsync();
        var users = JsonSerializer.Deserialize<RitDto[]>(content, jsonOptions);

        if (users is null)
        {
            return [];
        }

        return users;
    }
}
