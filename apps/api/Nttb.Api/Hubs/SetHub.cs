using Microsoft.AspNetCore.SignalR;

namespace Nttb.Api.Hubs;

public class SetHub : Hub
{
    private static string? LastUser = null;
    private static string? LastMessage = null;
    
    public async Task SendMessage(string user, string message)
    {
        LastMessage = message;
        LastUser = user;
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task Recall()
    {
        if (LastUser == null) return;
        await Clients.Caller.SendAsync("ReceiveMessage", LastUser, LastMessage);
    }
}