using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chatApplication
{
    public class ChatHub : Hub
    {
        public void Send(string user, string room, string msg)
        {
            Groups.Add(Context.ConnectionId, room);
            Clients.Group(room).broadcastMessage(user, room, msg);
        }
    }
}