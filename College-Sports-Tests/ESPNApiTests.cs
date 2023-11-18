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
        string dateStr = "2023-10-27T21:24:09.720+0000"; // Your JSON value

        var didParse = DateTime.TryParseExact(dateStr, "yyyy-MM-ddTHH:mm:ss.fffzzz", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.None, out DateTime date);

        Assert.IsTrue(didParse);
        Assert.IsNotNull(date);
    }
}