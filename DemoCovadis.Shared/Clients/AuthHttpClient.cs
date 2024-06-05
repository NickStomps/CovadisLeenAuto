﻿using DemoCovadis.Shared.Requests;
using DemoCovadis.Shared.Responses;
using System.Text;
using System.Text.Json;

namespace DemoCovadis.Shared.Clients;

public class AuthHttpClient
{
    private readonly HttpClient client;
    public static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public AuthHttpClient(IHttpClientFactory httpClientFactory)
    {
        client = httpClientFactory.CreateClient();
        client.BaseAddress = new Uri("http://localhost:5077/Auth");
    }

    public async Task<AuthResponse?> Login(LoginRequest loginRequest)
    {
        var content = new StringContent(JsonSerializer.Serialize(loginRequest), Encoding.UTF8, "application/json");
        var response = await client.PostAsync(string.Empty, content);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        var authResponse = JsonSerializer.Deserialize<AuthResponse>(responseContent, SerializerOptions);

        return authResponse;
    }
}