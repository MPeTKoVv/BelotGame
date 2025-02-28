using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelotGame.Shared.Models
{
    public class Card
    {
        public string Suit { get; set; } // Hearts, Diamonds, Clubs, Spades
        public string Value { get; set; } // 7, 8, 9, 10, J, Q, K, A
    }
}
