using College_Sports_Domain;
using PuppeteerSharp;

public class FetchingService
{
    public static async Task<ScoreboardResult> FetchScoreboard(DateOnly? dateOnly = null)
    {
        dateOnly ??= DateOnly.FromDateTime(DateTime.UtcNow);

        var dateString = dateOnly.Value.ToString("yyyyMMdd");

        using var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync();
        await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
        await using var page = await browser.NewPageAsync();

        // Group 50 is all division 1 games
        await page.GoToAsync(
            $"https://www.espn.com/mens-college-basketball/scoreboard/_/date/{dateString}/group/50",
            WaitUntilNavigation.Networkidle2);

        var htmlString = await page.GetContentAsync();

        var scoreboardItems = ParsingService.ParseHtmlToScoreboardItems(htmlString);

        return new ScoreboardResult()
        {
            FetchDateTime = DateTime.UtcNow,
            FilterDate = dateOnly.Value,
            ScoreboardItems = scoreboardItems,
        };
    }
}