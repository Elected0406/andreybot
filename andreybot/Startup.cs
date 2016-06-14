using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(andreybot.Startup))]
namespace andreybot
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
