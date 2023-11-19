using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
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

        [HttpGet("scoreboard")]
        public async Task<ActionResult<ScoreboardResult>> GetScoreboard([FromQuery] DateOnly? filterDate = null)
        {
            filterDate ??= DateOnly.FromDateTime(DateTime.UtcNow);

            var storedScoreboardFetch = await _context.ScoreboardFetches
                .AsNoTracking()
                .OrderByDescending(x => x.FetchedDateTime)
                .FirstOrDefaultAsync(x => x.FilterDate == filterDate.Value);

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

                return newScoreboardResult;
            }
        }
    }
}