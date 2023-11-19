
using System.Text.Json;
using College_Sports_Domain.Models;
using College_Sports_WebApp.Database;
using College_Sports_WebApp.Services;
using Microsoft.EntityFrameworkCore;

public class ESPNFetchingService : BackgroundService
{
    private readonly ESPNApiService _espnApiService;
    private readonly IServiceScopeFactory _scopeFactory;

    public ESPNFetchingService(ESPNApiService espnApiService, IServiceScopeFactory scopeFactory)
    {
        _espnApiService = espnApiService;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // This prevents the whole API from stalling when running this service
        await Task.Yield();

        var random = new Random();

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                Console.WriteLine("Fetching scoreboard from ESPN");

                // Get the offset from UTC for the American/New_York timezone
                var offset = TimeZoneInfo.FindSystemTimeZoneById("America/New_York").GetUtcOffset(DateTime.UtcNow);

                // Get the current date in the American/New_York timezone from a datetimeoffset
                var currentDate = DateOnly.FromDateTime(DateTimeOffset.UtcNow.ToOffset(offset).DateTime);

                // Fetch the scoreboard from the ESPN API
                var scoreboardResult = await _espnApiService.FetchScoreboard(currentDate);

                // Save the scoreboard result to the database if it exists
                if (scoreboardResult is null)
                {
                    Console.WriteLine("Unable to fetch scoreboard result");
                }
                else
                {
                    Console.WriteLine("Saving scoreboard result to database");

                    var scoreboardFetch = new ScoreboardFetch()
                    {
                        FilterDate = currentDate,
                        FetchedDateTime = DateTime.UtcNow,
                        JsonResponse = JsonSerializer.Serialize(scoreboardResult),
                    };

                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var context = scope.ServiceProvider.GetRequiredService<BaseDbContext>();

                        context.ScoreboardFetches.Add(scoreboardFetch);

                        await context.SaveChangesAsync();

                        // Remove the scoreboard fetches with a filter date that is the same as the current date
                        await context.ScoreboardFetches.Where(x => x.FilterDate == currentDate).ExecuteDeleteAsync();
                    }

                    Console.WriteLine("Saved scoreboard result to database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching the scoreboard from ESPN: {ex.Message}");
            }
            finally
            {
                // Random delay in seconds between 10 and 20 seconds
                var delay = random.Next(10, 20);

                await Task.Delay(TimeSpan.FromSeconds(delay), stoppingToken);
            }
        }
    }
}