using Microsoft.AspNetCore.SignalR;

namespace Blog.Application.Models;

public class PostHub : Hub
{
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
