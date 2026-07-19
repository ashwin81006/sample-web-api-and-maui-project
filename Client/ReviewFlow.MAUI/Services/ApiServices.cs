using System.Net.Http.Json;
using ReviewFlow.MAUI.Models;

namespace ReviewFlow.MAUI.Services;

public class ApiService
{

    private const string BaseUrl = "https://external-bargains-tsunami-nick.trycloudflare.com/api/"; //type ipconfig in your laptop and use the ipv4 address of your laptop in place of localhost

    private readonly HttpClient _httpClient = new();

    public async Task<ReviewRequest?> GetReviewById(int id)
    {
        return await _httpClient.GetFromJsonAsync<ReviewRequest>(
            $"{BaseUrl}Review/{id}");
    }

    public async Task<List<ReviewRequest>?> GetAllReviews()
    {
        return await _httpClient.GetFromJsonAsync<List<ReviewRequest>>(
            $"{BaseUrl}Review");
    }
}