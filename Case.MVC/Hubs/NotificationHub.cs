using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Case.MVC.Hubs
{
    public class NotificationHub : Hub
    {
        [HubMethodName("sendMessages")]
        public static void SendMessages(string action)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.updateMessages(action);
        }

    }
}