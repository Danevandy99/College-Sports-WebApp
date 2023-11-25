using System.Text.Json;
using College_Sports_Domain.Models;
using College_Sports_WebApp.Database;
using College_Sports_WebApp.Database.Models;
using College_Sports_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ESPNApiController : ControllerBase
    {
        private readonly BaseDbContext _context;
        private readonly ESPNApiService _espnApiService;

        public ESPNApiController(BaseDbContext context, ESPNApiService espnApiService)
        {
            _context = context;
            _espnApiService = espnApiService;
        }

        [HttpGet("conferences")]
        public async Task<ActionResult<ConferencesResult>> GetConferences()
        {
            var oneWeekAgo = DateTime.UtcNow.AddDays(-7);

            var storedConferencesFetch = await _context.ConferencesFetches
                .AsNoTracking()
                .OrderByDescending(x => x.FetchedDateTime)
                .FirstOrDefaultAsync(x => x.FetchedDateTime >= oneWeekAgo);

            if (storedConferencesFetch is not null)
            {
                Console.WriteLine("Found stored conferences result");

                var result = JsonSerializer.Deserialize<ConferencesResult>(storedConferencesFetch.JsonResponse);

                if (result is null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Unable to deserialize stored conferences result");
                }

                return Ok(result);
            }
            else
            {
                Console.WriteLine("Fetching new conferences result");

                var newConferencesResult = await _espnApiService.FetchConferences();

                if (newConferencesResult is null)
                {
                    return NotFound("Unable to fetch conferences result");
                }

                var newConferencesFetch = new ConferencesFetch
                {
                    JsonResponse = JsonSerializer.Serialize(newConferencesResult),
                };

                await _context.ConferencesFetches.ExecuteDeleteAsync();

                _context.ConferencesFetches.Add(newConferencesFetch);
                await _context.SaveChangesAsync();

                return newConferencesResult;
            }
        }

        [HttpGet("scoreboard")]
        public async Task<ActionResult<ScoreboardResult>> GetScoreboard([FromQuery] DateOnly? filterDate = null)
        {
            filterDate ??= DateOnly.FromDateTime(DateTime.UtcNow);

            var tenSecondsAgo = DateTime.UtcNow.AddSeconds(-600);

            var storedScoreboardFetch = await _context.ScoreboardFetches
                .AsNoTracking()
                .OrderByDescending(x => x.FetchedDateTime)
                .FirstOrDefaultAsync(x => x.FilterDate == filterDate.Value && x.FetchedDateTime >= tenSecondsAgo);

            if (storedScoreboardFetch is not null)
            {
                Console.WriteLine("Found stored scoreboard result");

                var result = JsonSerializer.Deserialize<ScoreboardResult>(storedScoreboardFetch.JsonResponse);

                if (result is null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Unable to deserialize stored scoreboard result");
                }

                return Ok(result);
            }
            else
            {
                Console.WriteLine("Fetching new scoreboard result");

                var newScoreboardResult = await _espnApiService.FetchScoreboard(filterDate);

                if (newScoreboardResult is null)
                {
                    return NotFound("Unable to fetch scoreboard result");
                }

                var newScoreboardFetch = new ScoreboardFetch
                {
                    FilterDate = filterDate.Value,
                    JsonResponse = JsonSerializer.Serialize(newScoreboardResult),
                };

                _context.ScoreboardFetches.Add(newScoreboardFetch);
                await _context.SaveChangesAsync();

                // Remove the scoreboard fetches with a filter date that matches the current filter date
                await _context.ScoreboardFetches.Where(x => x.FilterDate == filterDate).ExecuteDeleteAsync();

                return newScoreboardResult;
            }
        }
    }
}