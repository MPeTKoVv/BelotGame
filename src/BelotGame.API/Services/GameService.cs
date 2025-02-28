using BelotGame.Shared.Models;

namespace BelotGame.API.Services
{
    public class GameService
    {
        private readonly List<Game> _games = new();

        public Game CreateGame(List<Player> players)
        {
            var game = new Game { Players = players };
            game.DealCards();
            _games.Add(game);
            return game;
        }

        public Game? GetGame(int gameId)
        {
            return _games.FirstOrDefault(g => g.Id == gameId);
        }

        public void PlayCard(int gameId, int playerId, Card card)
        {
            var game = GetGame(gameId);
            if (game != null && game.PlayerHands[playerId].Contains(card))
            {
                game.PlayerHands[playerId].Remove(card);
                // TODO: Implement round logic
            }
        }
    }
}
