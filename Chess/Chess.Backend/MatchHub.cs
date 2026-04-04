using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chess.Backend
{
    public class MatchHub : Hub
    {
        public async Task ConnectToMatch(Guid matchId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, matchId.ToString());
        }

        public async Task SendMove(Guid matchId, string move)
        {
            await Clients.OthersInGroup(matchId.ToString()).SendAsync("Receive", move);
        }
    }
}
