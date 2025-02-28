using Microsoft.AspNetCore.SignalR;

namespace BelotGame.API.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task PlayCard(string player, string card)
        {
            await Clients.All.SendAsync("CardPlayed", player, card);
        }
    }
}
