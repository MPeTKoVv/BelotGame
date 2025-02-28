
namespace BelotGame.Shared.Models
{
    public class Game
    {
        public int Id { get; set; }
        public List<Player> Players { get; set; } = new(); // Up to 4 players
        public string TrumpSuit { get; set; } // Hearts, Diamonds, Clubs, Spades
        public List<Card> Deck { get; set; } = new(); // The deck of cards
        public Dictionary<int, List<Card>> PlayerHands { get; set; } = new(); // Player hands
        public int CurrentRound { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public string Status { get; set; } = "Waiting"; // Waiting, Playing, Finished

        public Game()
        {
            InitializeDeck();
            ShuffleDeck();
        }

        private void InitializeDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] values = { "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    Deck.Add(new Card { Suit = suit, Value = value });
                }
            }
        }

        private void ShuffleDeck()
        {
            Random rng = new();
            Deck.Sort((a, b) => rng.Next(-1, 2));
        }

        public void DealCards()
        {
            int playerIndex = 0;
            foreach (var card in Deck)
            {
                if (!PlayerHands.ContainsKey(playerIndex))
                    PlayerHands[playerIndex] = new List<Card>();

                PlayerHands[playerIndex].Add(card);
                playerIndex = (playerIndex + 1) % 4; // Distribute to 4 players
            }
        }
    }
}
