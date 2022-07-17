using chatApplication.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace chatApplication
{
    public class OneToOne : PersistentConnection
    {
        private readonly ChatContext db;

        public OneToOne()
        {
            this.db = new ChatContext();
        }
        protected override Task OnConnected(IRequest request, string connectionId)
        {
            User newUser = new User() { UserId = connectionId, Name = request.QueryString["userName"] };
            PopulateServer(newUser);

            IList<string> idList = GetUserId();
            var userList = GetUsers();
            return Connection.Send(idList, userList);
        }

        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            var txtMsg = data.Split(':')[0];
            var conId = data.Split(':')[1];
            return Connection.Send(conId, txtMsg);
        }

        protected void PopulateServer(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        protected List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        protected List<string> GetUserId()
        {
            return db.Users.Select(w => w.UserId).ToList();
        }
    }
}