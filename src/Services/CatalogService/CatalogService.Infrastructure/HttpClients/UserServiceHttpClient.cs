using CatalogService.Application.Common.Interfaces;
using CatalogService.Application.Common.Models.Users;
using System.Net.Http.Json;

namespace CatalogService.Infrastructure.HttpClients;

public class UserServiceHttpClient : IUserServiceClient
{
    private readonly HttpClient _httpClient;

    public UserServiceHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<UserDto> GetUserAsync(Guid userId)
    {
        // Make an HTTP GET request to fetch user from UserService
        HttpResponseMessage response = await _httpClient.GetAsync($"api/User/{userId}");

        // Check if the request was successful
        response.EnsureSuccessStatusCode();

        // Deserialize the response body into UserDto
        return await response.Content.ReadFromJsonAsync<UserDto>();
    }
}