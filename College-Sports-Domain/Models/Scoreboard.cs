public class PartialScoreboardResult
{
    public int Id { get; set; }
    public DateTime FetchDateTime { get; set; }
    public DateOnly FilterDate { get; set; }
    public ICollection<ScoreboardItem> ScoreboardItems { get; set; } = new List<ScoreboardItem>();
}

public class ScoreboardItem
{
    public int Id { get; set; }
    public required ScoreboardScoreCell ScoreCell { get; set; }
    public required ScoreboardEventInfo EventInfo { get; set; }
    public required ScoreboardCallouts Callouts { get; set; }
}

public class ScoreboardScoreCell
{
    public int Id { get; set; }
    public required DateTime Time { get; set; }
    public required ICollection<ScoreboardScoreCellItem> Competitors { get; set; }
}

public class ScoreboardScoreCellItem
{
    public int Id { get; set; }
    public bool IsAway { get; set; }
    public required string TeamName { get; set; }
    public required string LogoUrl { get; set; }
    public required ScoreboardScoreCellItemRecord Record { get; set; }
}

public class ScoreboardScoreCellItemRecord
{
    public int Id { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
}

public class ScoreboardEventInfo
{
    public int Id { get; set; }
    public required string LocationHeadline { get; set; }
    public required string LocationDetail { get; set; }
}


public class ScoreboardCallouts
{
    public int Id { get; set; }
    public string? GamecastLink { get; set; }
}