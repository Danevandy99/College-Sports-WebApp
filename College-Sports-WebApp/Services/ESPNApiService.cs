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
        // URL example: https://site.web.api.espn.com/apis/site/v2/sports/basketball/mens-college-basketball/scoreboard?region=us&lang=en&contentorigin=espn&limit=300&calendartype=offdays&includeModules=videos&dates=20231119&groups=50&tz=America%2FNew_York&buyWindow=1m&showAirings=live&showZipLookup=true

        var url = $"https://site.web.api.espn.com/apis/site/v2/sports/basketball/mens-college-basketball/scoreboard?region=us&lang=en&contentorigin=espn&limit=300&calendartype=offdays&includeModules=videos&dates={date:yyyyMMdd}&groups=50&tz=America%2FNew_York&buyWindow=1m&showAirings=live&showZipLookup=true";

        var response = await _client.GetFromJsonAsync<ScoreboardResult>(url);

        return response;
    }
}