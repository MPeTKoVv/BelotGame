using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using BelotGame.Shared.Models;

namespace BelotGame.API.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task PlayCard(string playerName, string card)
        {
            await Clients.All.SendAsync("CardPlayed", playerName, card);
        }
    }
}
