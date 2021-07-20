using Flunt.Notifications;
using System.Collections.Generic;

namespace BackEndChallengeDotNet.Application.Notifications
{
    public class Result : Notifiable<Notification>
    {
        public ErrorCode? Error { get; set; }

        public Result(IReadOnlyCollection<Notification> notifications)
        {
            AddNotifications(notifications);
        }
        public Result(IReadOnlyCollection<Notification> notifications, ErrorCode error)
            : this(notifications)
        {
            Error = error;
        }

        public void AddNotification(string error)
        {
            AddNotification(string.Empty, error);
        }
        public void AddNotification(ErrorCode errorCode)
        {
            AddNotification(string.Empty, string.Empty);
            Error = errorCode;
        }
        public void AddNotification(string error, ErrorCode errorCode)
        {
            AddNotification(string.Empty, error);
            Error = errorCode;
        }
        public void AddNotification(string error, ErrorCode code, ErrorCode errorCode)
        {
            AddNotification(string.Empty, error, code);
            Error = errorCode;
        }
        public void AddNotification(string property, string message, ErrorCode errorCode)
        {
            AddNotification(property, message);
            Error = errorCode;
        }        
        public void AddNotification(Notification notification, ErrorCode errorCode)
        {
            AddNotification(notification);
            Error = errorCode;
        }
        public void AddNotifications(IReadOnlyCollection<Notification> notifications, ErrorCode errorCode)
        {
            AddNotifications(notifications);
            Error = errorCode;
        }

        public bool IsInvalid() => !IsValid;
    }
}
