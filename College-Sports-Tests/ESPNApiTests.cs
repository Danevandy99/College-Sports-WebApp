using System.Globalization;
using System.Runtime.Serialization;
using System.Text.Json;
using College_Sports_WebApp.Database.Models;

namespace College_Sports_Tests;

[TestFixture]
public class ESPNApiTests
{
    [Test]
    public void CanParse()
    {
        var scoreboardJSONString = File.ReadAllText("test-files/test-scoreboard.json");

        Assert.DoesNotThrow(() =>
        {
            var scoreboard = JsonSerializer.Deserialize<ScoreboardResult>(scoreboardJSONString);
        });
    }

    [Test]
    public void CanParse2()
    {
        var scoreboardJSONString = File.ReadAllText("test-files/test-scoreboard2.json");

        Assert.DoesNotThrow(() =>
        {
            var scoreboard = JsonSerializer.Deserialize<ScoreboardResult>(scoreboardJSONString);
        });
    }

    [Test]
    public void ParseDateFormat()
    {
        string dateStr = "2023-11-18T22:00:00+0000"; // Your JSON value

        var didParse = DateTimeOffset.TryParseExact(dateStr, "yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTimeOffset date);

        Console.WriteLine(dateStr, date.ToString("yyyy-MM-ddTHH:mm:ss.fffzzz"));

        Assert.IsTrue(didParse);
        Assert.IsNotNull(date);
    }
}