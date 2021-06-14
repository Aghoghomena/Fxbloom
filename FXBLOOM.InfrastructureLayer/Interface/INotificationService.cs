using FXBLOOM.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FXBLOOM.InfrastructureLayer.Interface
{
    public interface INotificationService
    {
        Task<string> SignalRHubNotifier(NotificationResponse notification);
    }
}
