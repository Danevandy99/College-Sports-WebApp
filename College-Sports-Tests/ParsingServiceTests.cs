using System.Text.Json;
using System.Text.Json.Nodes;
using College_Sports_Domain;

namespace College_Sports_Tests;

public class ParsingServiceTests
{

    private string scoreboardHTMLString;

    [SetUp]
    public void Setup()
    {
        scoreboardHTMLString = new FetchingService().FetchScoreboard().GetAwaiter().GetResult();
    }

    [Test]
    public void DidFetchScoreboard()
    {
        Assert.IsNotNull(scoreboardHTMLString);
    }

    [Test]
    public void Test1()
    {
        var games = ParsingService.ParseHtmlToScoreboardItems(scoreboardHTMLString);

        Console.WriteLine(JsonSerializer.Serialize(games, new JsonSerializerOptions { WriteIndented = true }));
    }
}