using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelotGame.Shared.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}