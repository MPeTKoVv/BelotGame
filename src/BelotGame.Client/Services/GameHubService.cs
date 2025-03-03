using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components;

namespace BelotGame.Client.Services
{
    public class GameHubService
    {
        private HubConnection _hubConnection;
        public event Action<string, string> OnCardPlayed;

        public GameHubService()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7122/gamehub")
                .WithAutomaticReconnect()
                .Build();
        }

        public async Task Connect()
        {
            _hubConnection.On<string, string>("CardPlayed", (player, card) =>
            {
                OnCardPlayed?.Invoke(player, card);
            });

            await _hubConnection.StartAsync();
        }

        public async Task PlayCard(string player, string card)
        {
            if (_hubConnection.State == HubConnectionState.Connected)
            {
                await _hubConnection.InvokeAsync("PlayCard", player, card);
            }
        }
    }
}
