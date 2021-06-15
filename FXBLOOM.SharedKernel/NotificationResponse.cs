using System;
using System.Collections.Generic;
using System.Text;

namespace FXBLOOM.SharedKernel
{
    public class NotificationResponse
    {
        public string Message { get; set; }
        public string UserEmail { get; set; }
        public byte[] Document { get; set; }
        public bool HasAttachment { get; set; }

        public static NotificationResponse GetNotificationResponse(string message, string email)
        {
            return new NotificationResponse
            {
                Message = message,
                UserEmail = email,
                HasAttachment = false
            };
        }

        public static NotificationResponse GetNotificationResponseWithData(string message, string email, byte[] data)
        {
            return new NotificationResponse
            {
                Message = message,
                UserEmail = email,
                Document = data,
                HasAttachment = true
            };
        }
    }
}
