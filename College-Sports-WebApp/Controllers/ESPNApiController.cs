using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using College_Sports_WebApp.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ESPNApiController : ControllerBase
    {
        private readonly BaseDbContext _context;

        public ESPNApiController(BaseDbContext context)
        {
            _context = context;
        }

        [HttpGet("scoreboard")]
        public async Task<ActionResult<ScoreboardResult>> GetScoreboard([FromQuery] DateOnly? filterDate = null)
        {
            filterDate ??= DateOnly.FromDateTime(DateTime.UtcNow);

            var storedScoreboardResult = await _context.ScoreboardResults
                .Include(x => x.ScoreboardItems.Where(x => x.ScoreCell.Competitors.Any()))
                    .ThenInclude(x => x.ScoreCell)
                        .ThenInclude(x => x.Competitors)
                            .ThenInclude(x => x.Record)
                .FirstOrDefaultAsync(x => x.FilterDate == filterDate);

            if (storedScoreboardResult is not null)
            {
                Console.WriteLine("Found stored scoreboard result");

                return storedScoreboardResult;
            }
            else
            {
                Console.WriteLine("Fetching new scoreboard result");

                var newScoreboardResult = await FetchingService.FetchScoreboard(filterDate);

                _context.ScoreboardResults.Add(newScoreboardResult);
                await _context.SaveChangesAsync();

                return newScoreboardResult;
            }
        }
    }
}