using FXBLOOM.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using FXBLOOM.InfrastructureLayer.Interface;

namespace FXBLOOM.InfrastructureLayer.Implementation
{
    public class NotificationService : INotificationService
    {
        private readonly SignalRSettings _signalRSettings;

        public NotificationService(IOptions<SignalRSettings> signalRSettings)
        {
            _signalRSettings = signalRSettings.Value ?? throw new ArgumentNullException(nameof(signalRSettings));
        }

        public async Task<string> SignalRHubNotifier(NotificationResponse notification)
        {
            _ = notification ?? throw new ArgumentNullException(nameof(notification));

            HubConnection connection = new HubConnectionBuilder().WithUrl(_signalRSettings.FXBloomsHub)
                         .WithAutomaticReconnect()
                         .Build();
            await connection.StartAsync();
            await connection.SendAsync("SendMessage", notification);

            return "Successfully sent message to client";
        }
    }
}
