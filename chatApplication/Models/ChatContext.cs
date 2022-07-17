using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace chatApplication.Models
{
    public class ChatContext : DbContext
    {
        public ChatContext() : base("chatDbConnection")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}