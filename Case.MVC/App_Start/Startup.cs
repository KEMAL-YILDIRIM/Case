using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Case.MVC.App_Start.Startup))]
namespace Case.MVC.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}