using BackEndChallengeDotNet.Application.Extensions;
using BackEndChallengeDotNet.Application.Notifications;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace BackEndChallengeDotNet.Application.ReponseError
{
    public class ApiError
    {        
        public string Message { get; set; }
        public ICollection<ErrorData> Errors { get; set; }

        public ApiError(string message, ICollection<Notification> errors)
        {
            Message = message;
            Errors = errors.Select(x => (ErrorData)x).ToList();
        }

        public static ApiError FromResult(Result result)
        {               
            var message = string.Format((result.Error ?? ErrorCode.BadRequest).TryGetDescription("Error ocurred."));
            var notifications = result.Notifications.ToList();
            return new ApiError(message, notifications);
        }
    }
}
