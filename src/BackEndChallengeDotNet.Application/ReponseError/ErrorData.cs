using Flunt.Notifications;

namespace BackEndChallengeDotNet.Application.ReponseError
{
    public class ErrorData
    {        
        public string Message { get; set; }
        public string Path { get; set; }

        public static explicit operator ErrorData(Notification notification)
        {
            return new ErrorData
            {
                Message = notification.Message,
                Path = notification.Key,
            };
        }
    }
}
