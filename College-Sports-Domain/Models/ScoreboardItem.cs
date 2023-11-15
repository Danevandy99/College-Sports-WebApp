
public class ScoreboardItem
{
    public required string Id { get; set; }
    public required ScoreboardScoreCell ScoreCell { get; set; }
    public required ScoreboardEventInfo EventInfo { get; set; }
    public required TeamInformation TeamInfo { get; set; }
    public required ScoreboardCallouts Callouts { get; set; }
}

public class ScoreboardScoreCell
{
    public required string Time { get; set; }
    public required List<ScoreboardScoreCellItem> Competitors { get; set; }
}

public class ScoreboardScoreCellItem
{
    public bool IsAway { get; set; }
    public required string TeamName { get; set; }
    public required string LogoUrl { get; set; }
    public required string Record { get; set; }
}

public class ScoreboardEventInfo
{
    public required string LocationHeadline { get; set; }
    public required string LocationDetail { get; set; }
}

public class TeamInformation
{
    public required List<TeamLink> Links { get; set; }
}

public class TeamLink
{
    public required string TeamName { get; set; }
    public required string LogoUrl { get; set; }
    public required List<string> Links { get; set; }
}

public class ScoreboardCallouts
{
    public required string GamecastLink { get; set; }
}