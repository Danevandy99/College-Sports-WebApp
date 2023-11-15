using System.Globalization;
using HtmlAgilityPack;

namespace College_Sports_Domain;

public class ParsingService
{
    public static List<ScoreboardItem> ParseHtmlToScoreboardItems(string html)
    {
        List<ScoreboardItem> scoreboards = new List<ScoreboardItem>();

        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);

        var scoreboardNodes = doc.DocumentNode.SelectNodes("//section[contains(@class, 'Scoreboard')]");

        if (scoreboardNodes != null)
        {
            foreach (var scoreboardNode in scoreboardNodes)
            {
                ScoreboardItem scoreboard = new ScoreboardItem
                {
                    ScoreCell = ParseScoreboardScoreCell(scoreboardNode),
                    EventInfo = ParseScoreboardEventInfo(scoreboardNode),
                    Callouts = ParseScoreboardCallouts(scoreboardNode)
                };

                scoreboards.Add(scoreboard);
            }
        }

        return scoreboards;
    }

    static ScoreboardScoreCell ParseScoreboardScoreCell(HtmlNode node)
    {
        var timeString = node.SelectSingleNode(".//div[contains(@class, 'ScoreCell__Time')]")?.InnerText?.Trim() ?? "";

        // Convert the time (8:00 PM) to a datetime
        DateTime.TryParseExact(timeString, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out var time);

        ScoreboardScoreCell scoreCell = new ScoreboardScoreCell
        {
            Time = time,
            Competitors = node.SelectNodes(".//ul[contains(@class, 'ScoreboardScoreCell__Competitors')]/li")
                ?.Select(ParseScoreboardScoreCellItem)
                .ToList() ?? new List<ScoreboardScoreCellItem>()
        };

        return scoreCell;
    }

    static ScoreboardScoreCellItem ParseScoreboardScoreCellItem(HtmlNode node)
    {
        var recordString = node.SelectSingleNode(".//span[@class='ScoreboardScoreCell__Record']")?.InnerText;
        var isAway = node.GetAttributeValue("class", "").Contains("away");
        var record = new ScoreboardScoreCellItemRecord();

        if (!string.IsNullOrEmpty(recordString))
        {
            var parts = recordString.Split('-');

            int.TryParse(parts[0], out var wins);
            record.Wins = wins;

            int.TryParse(parts[1], out var losses);
            record.Losses = losses;
        }

        ScoreboardScoreCellItem competitor = new ScoreboardScoreCellItem
        {
            IsAway = isAway,
            TeamName = node.SelectSingleNode(".//div[contains(@class, 'ScoreCell__TeamName')]")?.InnerText?.Trim() ?? "",
            LogoUrl = node.SelectSingleNode(".//img[contains(@class, 'ScoreboardScoreCell__Logo')]")?.GetAttributeValue("src", "") ?? "",
            Record = record,
        };

        return competitor;
    }

    static ScoreboardEventInfo ParseScoreboardEventInfo(HtmlNode node)
    {
        ScoreboardEventInfo eventInfo = new ScoreboardEventInfo
        {
            LocationHeadline = node.SelectSingleNode(".//div[contains(@class, 'LocationDetail__Item--headline')]")?.InnerText?.Trim() ?? "",
            LocationDetail = node.SelectSingleNode(".//div[@class='LocationDetail__Item']")?.InnerText?.Trim() ?? "",
        };

        return eventInfo;
    }

    static ScoreboardCallouts ParseScoreboardCallouts(HtmlNode node)
    {
        ScoreboardCallouts callouts = new ScoreboardCallouts
        {
            GamecastLink = node.SelectSingleNode(".//a[contains(@class, 'AnchorLink')]")?.GetAttributeValue("href", ""),
        };

        return callouts;
    }
}
