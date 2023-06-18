using Microsoft.AspNetCore.Authorization;

namespace StudentAffairWeb.Server;

public class ChatHub : Hub
{
    public async Task SendBroadCast(Message message) => await Clients.All.SendAsync("BroadCast",message);
}
