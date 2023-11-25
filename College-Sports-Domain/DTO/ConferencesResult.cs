public class Conference
{
    public required string uid { get; set; }
    public required string groupId { get; set; }
    public required string name { get; set; }
    public required string shortName { get; set; }
    public string? logo { get; set; }
    public string? parentGroupId { get; set; }
}

public class ConferencesResult
{
    public List<Conference> conferences { get; set; } = new();
}