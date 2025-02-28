using BelotGame.API.Services;
using BelotGame.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace BelotGame.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService = new();

        [HttpPost("create")]
        public IActionResult CreateGame([FromBody] List<Player> players)
        {
            var game = _gameService.CreateGame(players);
            return Ok(game);
        }

        [HttpGet("{gameId}")]
        public IActionResult GetGame(int gameId)
        {
            var game = _gameService.GetGame(gameId);
            if (game == null) return NotFound();
            return Ok(game);
        }

        [HttpPost("{gameId}/play/{playerId}")]
        public IActionResult PlayCard(int gameId, int playerId, [FromBody] Card card)
        {
            _gameService.PlayCard(gameId, playerId, card);
            return Ok();
        }
    }
}