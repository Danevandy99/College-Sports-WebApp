using System.Runtime.CompilerServices;
using System.Text.Json;
using College_Sports_WebApp.Database.Models;

namespace College_Sports_WebApp.Services;

public class ESPNApiService
{
    private readonly HttpClient _client;

    public ESPNApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<ScoreboardResult?> FetchScoreboard(DateOnly? date = null)
    {
        date ??= DateOnly.FromDateTime(DateTime.UtcNow);

        var url = $"https://site.web.api.espn.com/apis/site/v2/sports/basketball/mens-college-basketball/scoreboard?region=us&lang=en&contentorigin=espn&limit=300&calendartype=offdays&includeModules=videos&dates={date:yyyyMMdd}&groups=50&tz=America%2FNew_York&buyWindow=1m&showAirings=live&showZipLookup=true";

        return await Fetch<ScoreboardResult>(url);
    }

    public async Task<ConferencesResult?> FetchConferences()
    {
        var url = "https://site.web.api.espn.com/apis/site/v2/sports/basketball/mens-college-basketball/scoreboard/conferences?groups=50";

        return await Fetch<ConferencesResult>(url);
    }
    private async Task<T?> Fetch<T>(string url, [CallerMemberName] string? caller = null)
    {
        var responseString = await _client.GetStringAsync(url);

        try
        {
            var response = JsonSerializer.Deserialize<T>(responseString);

            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine(responseString);
            Console.WriteLine(ex.Message);

            // Get temp folder path
            var tempPath = Path.GetTempPath();

            var filePath = Path.Combine(tempPath, $"caller-{DateTime.UtcNow:yyyyMMdd}.json");

            // Save the response to a file for debugging
            await File.WriteAllTextAsync(filePath, responseString);

            // Print the full file path for the response file
            Console.WriteLine($"Saved {caller} response to {Path.GetFullPath(filePath)}");

            return default;
        }
    } 
}