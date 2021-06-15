using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FXBLOOM.SharedKernel;

namespace FXBLOOM.PresentationLayer.Hubs
{
    public class NotificationHub : Hub
    {
        public NotificationHub()
        {
        }

        public async Task SendMessage(NotificationResponse notificationObject)
        {
            await this.Clients.All.SendAsync("ReceiveNotification", notificationObject);
        }
    }
}
