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
                    Id = scoreboardNode.GetAttributeValue("id", ""),
                    ScoreCell = ParseScoreboardScoreCell(scoreboardNode),
                    EventInfo = ParseScoreboardEventInfo(scoreboardNode),
                    TeamInfo = ParseTeamInformation(scoreboardNode),
                    Callouts = ParseScoreboardCallouts(scoreboardNode)
                };

                scoreboards.Add(scoreboard);
            }
        }

        return scoreboards;
    }

    static ScoreboardScoreCell ParseScoreboardScoreCell(HtmlNode node)
    {
        ScoreboardScoreCell scoreCell = new ScoreboardScoreCell
        {
            Time = node.SelectSingleNode(".//div[contains(@class, 'ScoreCell__Time')]")?.InnerText.Trim(),
            Competitors = node.SelectNodes(".//ul[contains(@class, 'ScoreboardScoreCell__Competitors')]/li")
                ?.Select(ParseScoreboardScoreCellItem)
                .ToList() ?? new List<ScoreboardScoreCellItem>()
        };

        return scoreCell;
    }

    static ScoreboardScoreCellItem ParseScoreboardScoreCellItem(HtmlNode node)
    {
        ScoreboardScoreCellItem competitor = new ScoreboardScoreCellItem
        {
            IsAway = node.GetAttributeValue("class", "").Contains("away"),
            TeamName = node.SelectSingleNode(".//div[contains(@class, 'ScoreCell__TeamName')]")?.InnerText.Trim(),
            LogoUrl = node.SelectSingleNode(".//img[contains(@class, 'ScoreboardScoreCell__Logo')]")?.GetAttributeValue("src", ""),
            Record = node.SelectSingleNode(".//div[contains(@class, 'ScoreboardScoreCell__Record')]")?.InnerText.Trim()
        };

        return competitor;
    }

    static ScoreboardEventInfo ParseScoreboardEventInfo(HtmlNode node)
    {
        ScoreboardEventInfo eventInfo = new ScoreboardEventInfo
        {
            LocationHeadline = node.SelectSingleNode(".//div[contains(@class, 'LocationDetail__Item--headline')]")?.InnerText.Trim(),
            LocationDetail = node.SelectSingleNode(".//div[contains(@class, 'LocationDetail__Item')]")?.InnerText.Trim()
        };

        return eventInfo;
    }

    static TeamInformation ParseTeamInformation(HtmlNode node)
    {
        TeamInformation teamInfo = new TeamInformation
        {
            Links = node.SelectNodes(".//section[contains(@class, 'TeamLinks')]/div[contains(@class, 'ContentList__Item')]")
                ?.Select(ParseTeamLink)
                .ToList() ?? new List<TeamLink>()
        };

        return teamInfo;
    }

    static TeamLink ParseTeamLink(HtmlNode node)
    {
        TeamLink link = new TeamLink
        {
            TeamName = node.SelectSingleNode(".//h2")?.InnerText.Trim(),
            LogoUrl = node.SelectSingleNode(".//img[contains(@class, 'Image Logo Logo__xs')]")?.GetAttributeValue("src", ""),
            Links = node.SelectNodes(".//span[contains(@class, 'TeamLinks__Link')]/a")
                ?.Select(a => a.GetAttributeValue("href", ""))
                .ToList() ?? new List<string>()
        };

        return link;
    }

    static ScoreboardCallouts ParseScoreboardCallouts(HtmlNode node)
    {
        ScoreboardCallouts callouts = new ScoreboardCallouts
        {
            GamecastLink = node.SelectSingleNode(".//a[contains(@class, 'AnchorLink Button Button--sm Button--anchorLink Button--alt mb4 w-100 mr2')]")?.GetAttributeValue("href", "")
        };

        return callouts;
    }


}
