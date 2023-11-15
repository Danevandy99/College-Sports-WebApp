using FantasyData.Api.Client.Model.CBB;

namespace College_Sports_WebApp.Services;

// https://sportsdata.io/developers/api-documentation/ncaa-basketball#/free

public class SportsDataBasketballApiService
{
    private readonly HttpClient _client;

    public SportsDataBasketballApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<ScoreBasic>> GetScoresByDateAsync(DateTime date)
    {
        string requestUri = $"scores/json/ScoresBasic/{date:yyyy-MM-dd}";

        var scores = await _client.GetFromJsonAsync<List<ScoreBasic>>(requestUri);

        return scores ?? new();
    }
}