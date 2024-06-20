using DemoCovadis.Shared.Dtos;
using DemoCovadis.Shared.Requests;
using System.Text;
using System.Text.Json;

namespace DemoCovadis.Shared.Clients;

public class UserHttpClient
{
    private readonly HttpClient client;
    private readonly JsonSerializerOptions jsonOptions;

    public UserHttpClient(IHttpClientFactory httpClientFactory)
    {
        client = httpClientFactory.CreateClient(nameof(UserHttpClient));
        client.BaseAddress = new Uri("http://localhost:5077/User");

        jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<UserDto[]> GetUsers()
    {
        var response = await client.GetAsync(string.Empty);

        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        var content = await response.Content.ReadAsStringAsync();
        var users = JsonSerializer.Deserialize<UserDto[]>(content, jsonOptions);

        if (users is null)
        {
            return [];
        }

        return users;
    }

    public async Task<UserDto?> CreateUser(UserRequest request)
    {
        var jsonContent = JsonSerializer.Serialize(request);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(string.Empty, content);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        var createdUser = JsonSerializer.Deserialize<UserDto>(responseContent, jsonOptions);

        return createdUser;
    }
}