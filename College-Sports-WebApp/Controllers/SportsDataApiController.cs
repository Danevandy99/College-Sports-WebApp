using College_Sports_WebApp.Services;
using FantasyData.Api.Client.Model.CBB;
using Microsoft.AspNetCore.Mvc;

namespace College_Sports_WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SportsDataApiController : ControllerBase
    {
        private readonly SportsDataBasketballApiService _sportsDataBasketballApiService;

        public SportsDataApiController(SportsDataBasketballApiService sportsDataBasketballApiService)
        {
            _sportsDataBasketballApiService = sportsDataBasketballApiService;
        }

        [HttpGet("scores-by-date")]
        public async Task<ActionResult<List<ScoreBasic>>> GetScoresByDate([FromQuery] DateTime? date)
        {
            // Default to today's date if no date is provided
           date ??= DateTime.UtcNow;

            var scores = await _sportsDataBasketballApiService.GetScoresByDateAsync(date.Value);

            return Ok(scores.OrderBy(x => x.DateTime));
        }
    }
}