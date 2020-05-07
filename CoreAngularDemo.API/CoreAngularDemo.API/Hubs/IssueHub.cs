using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using CoreAngularDemo.API.Extensions;

namespace CoreAngularDemo.API.Hubs
{
    [Authorize(Roles = "ENGINEER")]
    public class IssueHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(
                Context.ConnectionId,
                Context.User.FindFirst(RoleNames.Schema)?.Value);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(
                Context.ConnectionId,
                Context.User.FindFirst(RoleNames.Schema)?.Value);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
