using chatApplication.Models;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(chatApplication.Startup))]

namespace chatApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR<OneToOne>("/test");
            app.MapSignalR();


        }
    }
}
