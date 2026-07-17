using System.Net.Http.Json;
using ReviewFlow.MAUI.Models;

namespace ReviewFlow.MAUI.Services;

public class ApiService
{
#if WINDOWS
    private const string BaseUrl = "http://localhost:5110/api/";
#else
    private const string BaseUrl = "https://blog-hunt-pioneer-bonus.trycloudflare.com/api/";
#endif

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