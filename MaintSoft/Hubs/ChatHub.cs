using MaintSoft.Core.Contracts;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Immutable;

namespace MaintSoft.Hubs
{
    public class ChatHub : Hub
    {
        //private readonly IUserService userService;

        //public ChatHub(IUserService _userService)
        //{
        //    _userService = userService;
        //}

        public async Task SendMessage(string user, string message)
        {

            await Clients.All.SendAsync("ReceiveMessage",user, message);

            //var maintenance = (await userService.GetAllApplicationUsersAsync())
            //    .Where(x => x.JobPosition.ToLower() == "engineer" ||
            //x.JobPosition.ToLower() == "technician").Select(x=> x.Id).ToList();
              
            //await Clients.Group("Maintenance").SendAsync("ReceiveMessage", user, message);
            //await Clients.Users(maintenance).SendAsync("ReceiveMessage", user, message);
        }
    }
}
