using PuppeteerSharp;

public class FetchingService
{
    public async Task<string> FetchScoreboard(DateOnly? dateOnly = null)
    {
        dateOnly ??= DateOnly.FromDateTime(DateTime.UtcNow);

        // 20231118
        var dateString = dateOnly.Value.ToString("yyyyMMdd");

        using var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync();
        await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
        await using var page = await browser.NewPageAsync();

        await page.GoToAsync(
            $"https://www.espn.com/mens-college-basketball/scoreboard/_/date/{dateString}/group/50",
            WaitUntilNavigation.Networkidle2);

        return await page.GetContentAsync();
    }
}