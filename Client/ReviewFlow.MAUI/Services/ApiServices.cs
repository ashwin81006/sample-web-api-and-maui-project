using System.Net.Http.Json;
using ReviewFlow.MAUI.Models;

namespace ReviewFlow.MAUI.Services;

public class ApiService
{
#if WINDOWS
    private const string BaseUrl = "http://localhost:5110/api/";
#else
    private const string BaseUrl = "https://hughes-liability-speeches-browsers.trycloudflare.com/api/"; //type ipconfig in your laptop and use the ipv4 address of your laptop in place of localhost
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