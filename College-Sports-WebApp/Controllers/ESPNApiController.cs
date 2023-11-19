using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            var storedScoreboardResult = await _context.ScoreboardResults
                .Include(x => x.events)
                    .ThenInclude(x => x.competitions)
                        .ThenInclude(x => x.competitors)
                .FirstOrDefaultAsync(x => x.eventsDate.date.Date == filterDate.Value.ToDateTime(TimeOnly.MinValue));

            if (storedScoreboardResult is not null)
            {
                Console.WriteLine("Found stored scoreboard result");

                return storedScoreboardResult;
            }
            else
            {
                Console.WriteLine("Fetching new scoreboard result");

                var newScoreboardResult = await _espnApiService.FetchScoreboard(filterDate);

                if (newScoreboardResult is null)
                {
                    return NotFound("Unable to fetch scoreboard result");
                }

                // Don't try to save it for now
                //_context.ScoreboardResults.Add(newScoreboardResult);
                //await _context.SaveChangesAsync();

                return newScoreboardResult;
            }
        }
    }
}